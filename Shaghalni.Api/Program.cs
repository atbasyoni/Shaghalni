
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shaghalni.Core;
using Shaghalni.Core.DTOs.Accounts;
using Shaghalni.Core.Helpers;
using Shaghalni.Core.Interfaces;
using Shaghalni.Core.Models.Accounts;
using Shaghalni.EF;
using Shaghalni.EF.Data;
using Shaghalni.EF.Helpers;
using Shaghalni.EF.Profiles;
using Shaghalni.EF.Repositories;
using System.Reflection;
using System.Text;

namespace Shaghalni.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IAuthRepository), typeof(AuthRepository));

            builder.Services.AddTransient<IEmailRepository, EmailRepository>();
            builder.Services.AddTransient<IEmailSenderRepository, EmailSenderRepository>();
            builder.Services.AddScoped<JwtHandler>();

            var emailConfiguration = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfigurationDTO>();
            builder.Services.AddSingleton(emailConfiguration);

            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                };
            });

            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
                {
                    CorsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
