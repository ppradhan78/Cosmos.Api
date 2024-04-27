namespace Cosmos.TableAPI.Data.BusinessObject
{
    public interface IConfigurationSettings
    {
        string CosmosDBAccountUri { get; }
        string CosmosDBAccountPrimaryKey { get; }
        string CosmosDbName { get; }
        string CosmosDBAccount { get; }
        string ConnectionStringSetting { get; }
        
    }
}
