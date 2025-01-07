using Microsoft.EntityFrameworkCore;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Domain.Models.FoodPlace;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonalDiary.Persistence
{
    public class DiaryDbContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<FoodPlace> FoodPlaces { get; set; }

        public DiaryDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetupUtcDateTimes(modelBuilder);

        }
        private static void SetupUtcDateTimes(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType
                    .GetProperties()
                    .ToList();

                foreach (var property in entityType.GetProperties())
                {
                    // Проверить, является ли свойство типом DateTime
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(
                            new ValueConverter<DateTime, DateTime>(
                                v => v.Kind == DateTimeKind.Unspecified
                                    ? DateTime.SpecifyKind(v, DateTimeKind.Utc).ToUniversalTime()
                                    : v.ToUniversalTime(), // Преобразование в UTC при сохранении
                                v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Преобразование обратно из базы
                            ));
                    }
                    else if (property.ClrType == typeof(DateTime?)) // Проверить, если это nullable
                    {
                        property.SetValueConverter(
                            new ValueConverter<DateTime?, DateTime?>(
                                v => v.HasValue
                                    ? (v.Value.Kind == DateTimeKind.Unspecified
                                        ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc).ToUniversalTime()
                                        : v.Value.ToUniversalTime())
                                    : null, // Если null, просто вернуть null
                                v => v.HasValue
                                    ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                                    : null // Если null, просто вернуть null
                            ));
                    }
                }
            }
        }
    }
}
