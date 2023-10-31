using AplicationLayer;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Entities;
using AplicationLayer.Common;
using Microsoft.AspNetCore.Identity;
using AplicationLayer.Interfaces;
using Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using AplicationLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var appSetting = builder.Configuration
                .GetSection(nameof(AppSetting))
                .Get<AppSetting>();

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(appSetting.ConnectionStrings.SqlServer.Url));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Appliction).Assembly));
            builder.Services.AddIdentity<User, Role>(identityOptions =>
            {
                identityOptions.Password.RequireDigit = appSetting.IdentitySettings.PasswordRequireDigit;
                identityOptions.Password.RequiredLength = appSetting.IdentitySettings.PasswordRequiredLength;
                identityOptions.Password.RequireNonAlphanumeric = appSetting.IdentitySettings.PasswordRequireNonAlphanumeric;

            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders(); 
            builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            builder.Services.AddTransient(typeof(ILoginService), typeof(LoginService));
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Appliction>();
            builder.Services.AddSingleton(appSetting.JwtSettings);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    var secretKey = Encoding.UTF8.GetBytes(appSetting.JwtSettings.SecretKey);
                    var encryptionKey = Encoding.UTF8.GetBytes(appSetting.JwtSettings.EncryptKey);
                    var validationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidAudience = appSetting.JwtSettings.Audience,
                        ValidateIssuer = true,
                        ValidIssuer = appSetting.JwtSettings.Issuer,
                        TokenDecryptionKey = new SymmetricSecurityKey(encryptionKey)
                    };
                    option.RequireHttpsMetadata = false;
                    option.SaveToken = true;
                    option.TokenValidationParameters = validationParameters;
                });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
