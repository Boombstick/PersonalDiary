using MediatR;
using System.Text;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using PersonalDiary.Persistence;
using PersonalDiary.Api.Filters;
using PersonalDiary.Api.Security;
using PersonalDiary.Api.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PersonalDiary.Domain.Repositories;
using PersonalDiary.Domain.Models.Users;
using PersonalDiary.Application.Interfaces;
using PersonalDiary.Persistence.Repositories;
using PersonalDiary.Application.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PersonalDiary.Application.Feature.Places.FoodPlaces;
using PersonalDiary.Persistence.Repositories.DictionaryRepository;
using PersonalDiary.Persistence.Repositories.PlaceRepositories.RateablePlaces;

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
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            // Repositories
            #region Places
            builder.Services.AddScoped<IFoodPlaceRepository, FoodPlaceRepository>();
            builder.Services.AddScoped<ICulturePlaceRepository, CulturePlaceRepository>();
            builder.Services.AddScoped<IWalkPlaceRepository, WalkPlaceRepository>();
            #endregion

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
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.UseSecurityTokenValidators = true; //В .net 8 по дефолту используются JsonWebSignature Без этого флага авторизация не работает
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["TokenManagement:Issuer"],
                    ValidAudience = builder.Configuration["TokenManagement:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["TokenManagement:Secret"]!))
                };
            });
            builder.Services.AddTransient<IJwtTokenProvider, JwtTokenProvider>();
            builder.Services.AddScoped<ICurrentUser, CurrentUser>();
            builder.Services.AddTransient<CurrentUserMiddleware>();


            builder.Services.AddScoped<CustomExceptionFilter>();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName.Replace("+", "."));
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Введите JWT токен, используя формат: Bearer {токен}"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            }
            );


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
            app.UseMiddleware<CurrentUserMiddleware>();

            app.MapControllers();

            await DatabaseInitializer.MigrateDatabase(app.Services);
            app.Run();
        }
    }
}
