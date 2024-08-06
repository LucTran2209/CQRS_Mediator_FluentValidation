using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using System.Text;
using T.Core.DependencyInjection.Options;
using T.Core.WithCQRS_Mediator.CQRS.ProductService.ModelCommandQuery;
using T.Core.WithoutCQRS_Mediator.Abstraction.ServiceInterfaces;
using T.Core.WithoutCQRS_Mediator.Services;

namespace T.Core.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }


        public static IServiceCollection AddDIService(this IServiceCollection services)
        {
            // Đăng ký MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

            // Đăng ký Validator
            services.AddValidatorsFromAssemblyContaining<ProductInsertCommandValidator>();

            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration section)
        {
            JwtConfig? jwtConfig = section.Get<JwtConfig>();

            if (jwtConfig is not null)
            {
                // Add Authentication
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = jwtConfig.ValidAudience,
                        ValidIssuer = jwtConfig.ValidIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret ?? string.Empty))
                    };
                });

            }
            return services;
        }
    }
}
