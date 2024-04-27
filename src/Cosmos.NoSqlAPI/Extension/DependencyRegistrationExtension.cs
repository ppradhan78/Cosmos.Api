using Cosmos.NoSqlAPI.Data.BusinessObject;
using Cosmos.NoSqlAPI.Data.BusinessObjects;
using Cosmos.NoSqlAPI.Data.Core;

namespace Cosmos.NoSqlAPI.Extension
{
    public static class DependencyRegistrationExtension
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection Services)
        {
            Services.AddTransient<IFeedProcessCosmosDBCore, FeedProcessCosmosDBCore>();
            Services.AddTransient<IFeedProcessCosmosDBBO, FeedProcessCosmosDBBO>();
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
