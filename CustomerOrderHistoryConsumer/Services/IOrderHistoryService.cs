using System;
using System.Collections.Generic;
using System.Text;
using CustomerOrderHistoryConsumer.BusinessObjects;

namespace CustomerOrderHistoryConsumer.Services
{
    public interface IOrderHistoryService
    {
        /// <summary>
        /// The service operation which will call the actual API and deserialize the JSON into the OrderHistoryItem object
        /// we will mock this method in our tests so that instead of calling the real API, it will mock the request and response
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        List<OrderHistoryItem> GetOrderHistory(string customerNumber);
    }
}