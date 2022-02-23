using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDbService.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MongoDbService.Impl
{
    public class CustomerService : ICustomerService
    {
        public readonly IMongoCollection<Customer> _customer;

        public readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerDatabaseSettings settings, ILogger<CustomerService> logger)
        {
            var connectionSettings = MongoClientSettings.FromConnectionString(settings.ConnectionString);
            connectionSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(connectionSettings);
            var database = client.GetDatabase(settings.DatabaseName);

            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
            _logger = logger;
        }

        ///<inheritdoc>
        public bool CreateCustomer(Customer customer)
        {
            _customer.InsertOne(customer);
            _logger.LogInformation("Added Customer to Mongo db Database {user}", JsonConvert.SerializeObject(customer));
            return true;
        }

        ///<inheritdoc>
        public bool DeleteCustomer(string id)
        {
            var response = _customer.DeleteOne(customer => customer.Id == id);
            _logger.LogInformation("Deleted Customer from Mongo db Database CustomerId:{user}", id);
            return response.DeletedCount > 0 ? true : false;
        }

        ///<inheritdoc>
        public Customer Get(string id)
        {
            var employee = _customer.Find<Customer>(customer => customer.Id == id).FirstOrDefault();
            _logger.LogInformation("Retrived Customer from Mongo db Database CustomerId:{user}", id);
            return employee;
        }

        ///<inheritdoc>
        public List<Customer> GetList()
        {
            var employees = _customer.Find(customer => true).ToList();
            _logger.LogInformation("Retrived All Customers Information from MongoDb");
            return employees;
        }
        
        ///<inheritdoc>
        public bool UpdateCustomer(Customer customer)
        {
           var result = _customer.ReplaceOne(x => x.Id == customer.Id, customer);
           _logger.LogInformation("Updated Customer in Mongo db Database CustomerId:{user}, Payload:{Payload}", customer.Id,JsonConvert.SerializeObject(customer));
            return result.ModifiedCount > 0 ? true : false;    
        }
    }
}
