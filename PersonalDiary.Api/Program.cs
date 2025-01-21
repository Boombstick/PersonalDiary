using MediatR;
using System.Text;
using Newtonsoft.Json;
using PersonalDiary.Persistence;
using PersonalDiary.Api.Filters;
using PersonalDiary.Api.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Users;
using PersonalDiary.Application.Interfaces;
using PersonalDiary.Persistence.Repositories;
using PersonalDiary.Application.Feature.Food;
using PersonalDiary.Application.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PersonalDiary.Persistence.Repositories.DictionaryRepository;

namespace PersonalDiary.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            // Repositories
            builder.Services.AddScoped<IFoodPlaceRepository, FoodPlaceRepository>();
            builder.Services.AddScoped<IMyTaskRepository, MyTaskRepository>();
            builder.Services.AddScoped<ITaskBoardRepository, TaskBoardRepository>();
            builder.Services.AddScoped<IDictionaryRepository, DictionaryRepository>();
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();

            // MediatR
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Create.Command).Assembly));
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // DbContext
            builder.Services.AddDbContext<DiaryDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DiaryDatabase")));
            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DiaryDbContext>()
            .AddDefaultTokenProviders();

            //Auth
            builder.Services.Configure<TokenManagement>(builder.Configuration.GetSection("TokenManagement"));
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["TokenManagement:Issuer"],
                    ValidAudience = builder.Configuration["TokenManagement:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenManagement:Secret"]!))
                };
            });
            builder.Services.AddTransient<IJwtTokenProvider, JwtTokenProvider>();


            builder.Services.AddScoped<CustomExceptionFilter>();
            builder.Services.AddSwaggerGen(option => option.CustomSchemaIds(type => type.FullName.Replace("+", ".")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            await DatabaseInitializer.MigrateDatabase(app.Services);
            app.Run();
        }
    }
}
