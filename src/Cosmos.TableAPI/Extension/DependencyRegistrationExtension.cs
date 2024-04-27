using Cosmos.TableAPI.Data.BusinessObject;
using Cosmos.TableAPI.Data.BusinessObjects;
using Cosmos.TableAPI.Data.Core;

namespace Cosmos.TableAPI.Extension
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection Services)
        {
            Services.AddTransient<IOrderCore, OrderCore>();
            Services.AddTransient<IOrderBo, OrderBo>();
            Services.AddSingleton<IConfigurationSettings, ConfigurationSettings>();
            return Services;
        }
        //public static IServiceCollection AddApiDependencies(this IServiceCollection Services)
        //{
        //    Services.AddEndpointsApiExplorer();
        //    //Services.Configure<ConfigurationSettings>(builder.Configuration.GetSection("AzureAISearch"));
        //    Services.AddSwaggerGen();
        //    Services.AddControllers();
        //    Services.AddApplicationInsightsTelemetry();
        //    Services.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowAllOrigins",
        //            builder =>
        //            {
        //                builder
        //                    .AllowAnyOrigin()
        //                    .AllowAnyHeader()
        //                    .AllowAnyMethod();
        //            });
        //    });
        //    return Services;
        //}
    }
}
