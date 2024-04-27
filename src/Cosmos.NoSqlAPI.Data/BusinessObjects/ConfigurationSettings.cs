using Microsoft.Extensions.Configuration;

namespace Cosmos.NoSqlAPI.Data.BusinessObject
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        #region Global Variable(s)
        private readonly IConfiguration _configuration;
        #endregion

        public ConfigurationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Public Prop(s)
        public string CosmosDBAccount => _configuration["CosmosDB:CosmosDBAccount"];
        public string CosmosDBAccountUri => _configuration["CosmosDB:CosmosDBAccountUri"];
        public string CosmosDBAccountPrimaryKey => _configuration["CosmosDB:CosmosDBAccountPrimaryKey"];
        public string CosmosDbName => _configuration["CosmosDB:CosmosDbName"];
        public string ConnectionStringSetting => _configuration["CosmosDB:ConnectionStringSetting"];
        
        #endregion

    }
}
