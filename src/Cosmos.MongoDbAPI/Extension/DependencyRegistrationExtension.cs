using Cosmos.MongoDbAPI.Data.BusinessObjects;
using Cosmos.MongoDbAPI.Data.BusinessObjects.Base;
using Cosmos.MongoDbAPI.Data.Core;

namespace Cosmos.MongoDbAPI.Extension
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection Services)
        {
            Services.AddTransient<IOrderDetailsCore, OrderDetailsCore>();
            Services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
            Services.AddScoped<IDatabaseContext, DatabaseContext>();
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
