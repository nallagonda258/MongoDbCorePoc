using MongoDbService.Models;
using System.Collections.Generic;

namespace MongoDbService.Impl
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get's Customer List
        /// </summary>
        /// <returns>List of Customer</returns>
        public List<Customer> GetList();

        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Customer Object</returns>
        public Customer Get(string id);

        /// <summary>
        /// CreateCustomer
        /// </summary>
        /// <param name="customer">customer Object</param>
        /// <returns>bool</returns>
        public bool CreateCustomer(Customer customer);

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="customer">Customer Object</param>
        /// <returns>bool</returns>
        public bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>bool</returns>
        public bool DeleteCustomer(string id);
    }
}
