using System;
using System.Collections.Generic;
using System.Text;
using CustomerOrderHistoryConsumer.Services;
using CustomerOrderHistoryConsumer.BusinessObjects;

namespace CustomerOrderHistoryConsumer
{
    /// <summary>
    /// This is the consumer of the API and OrderHistoryService will essentially have the HTTP client
    /// For the purpose of this assignment we don't need to have HTTP code as we are mocking the API calls
    /// </summary>
    public class APIConsumer
    {
        private IOrderHistoryService _orderHistoryService;

        public APIConsumer(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        /// <summary>
        /// This is the actual consumer which calls teh OrderHistoryService and that service essentials is a HTTP Client to cal the API
        /// For the purpose of this assignment we don't need to write HTTP Client as we are going to mock it
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public List<OrderHistoryItem> GetCustomerOrderHistory(string customerNumber)
        {
            return _orderHistoryService.GetOrderHistory(customerNumber);
        }
    }
}
