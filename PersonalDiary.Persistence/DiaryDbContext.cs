using PersonalDiary.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using PersonalDiary.Domain.Models.Users;
using PersonalDiary.Domain.Models.MyTask;
using PersonalDiary.Domain.Models.Reviews;
using PersonalDiary.Domain.Models.Places.FoodPlaces;
using PersonalDiary.Domain.Models.Places.WalkPlaces;
using PersonalDiary.Domain.Models.Places.CulturePlaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PersonalDiary.Persistence
{
    public class DiaryDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<TaskBoard> TaskBoards { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<WalkPlace> WalkPlaces { get; set; }
        public DbSet<WalkPlaceReview> WalkPlacesReviews { get; set; }

        public DbSet<CulturePlace> CulturePlaces { get; set; }
        public DbSet<CulturePlaceReview> CulturePlaceReviews { get; set; }

        public DbSet<FoodPlace> FoodPlaces { get; set; }
        public DbSet<FoodPlaceReview> FoodPlaceReviews { get; set; }

        public DiaryDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Преобразуем имя таблицы в snake_case
                entity.SetTableName(ToSnakeCase(entity.GetTableName()));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase((property.Name)));
                }
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(ToSnakeCase(key.GetName()));
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(ToSnakeCase(key.GetConstraintName()));
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()));
                }
            }

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Role>().ToTable("roles");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        }

        private string ToSnakeCase(string input)
        {
            // Преобразуем имя в нижний регистр с подчеркиваниями
            return Regex.Replace(
                Regex.Replace(input, @"([a-z])([A-Z])", "$1_$2"), // Разделяем строчные и заглавные буквы
                @"([A-Z])([A-Z][a-z])", "$1_$2")                // Разделяем заглавные и строчные после них
                .ToLower();
        }
    }
}
