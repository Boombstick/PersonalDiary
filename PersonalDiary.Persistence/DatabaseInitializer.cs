using Newtonsoft.Json;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalDiary.Domain.Models.Dictionaries;

namespace PersonalDiary.Persistence
{
    public static class DatabaseInitializer
    {
        public static async Task MigrateDatabase(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<DiaryDbContext>();
                    try
                    {
                        await context.Database.MigrateAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw new Exception("Alarm Миграции не применились");
                    }
                    if (context.Cities.Count() < 2)
                    {
                        await SeedCityDictionaryAsync(context);
                    }
                    else if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
                    {
                        await UpdateDictionaryAsync(context);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static async Task SeedCityDictionaryAsync(DiaryDbContext context)
        {

            var cities = GetDictionaryEntities<City>("Cities");
            await context.Cities.AddRangeAsync(cities);
            await context.SaveChangesAsync();
        }
        private static async Task UpdateDictionaryAsync(DiaryDbContext context)
        {
            var cities = GetDictionaryEntities<City>("Cities");

            foreach (var entry in cities)
            {
                var city = await context.Cities.FindAsync(entry.Id);
                if (city == null)
                {
                    await context.Cities.AddAsync(entry);
                    continue;
                }
                city.Name = entry.Name;
            }
            await context.SaveChangesAsync();
        }

        private static List<T> GetDictionaryEntities<T>(string resourceJsonFileNameWithoutExt)
        {
            try
            {
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(directory, "SeedData", $"{resourceJsonFileNameWithoutExt}.json");
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(json) ?? throw new Exception($"Не получилось прочитать json для файла ${resourceJsonFileNameWithoutExt}.json");
            }
            catch
            {
                throw;
            }
        }
    }
}
