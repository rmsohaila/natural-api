using AutoMapper;
using Starter.Contracts;
using Starter.Contracts.Services;
using Starter.CORE;
using Starter.DAL;
using Starter.Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Starter.Console.Configurations
{
    public static class ServiceConfigurationsExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SQLDBContext>();
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] {
                    "Starter.Console",
                    "Starter.CORE"
                });
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IAttributeDataTypeService, AttributeDataTypeService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IIntentService, IntentService>();
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<ITemplateService, TemplateService>();
        }


    }
}
