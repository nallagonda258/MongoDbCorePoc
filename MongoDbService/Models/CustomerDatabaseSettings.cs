namespace MongoDbService.Models
{
    public class CustomerDatabaseSettings : ICustomerDatabaseSettings
    {
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICustomerDatabaseSettings
    {
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
