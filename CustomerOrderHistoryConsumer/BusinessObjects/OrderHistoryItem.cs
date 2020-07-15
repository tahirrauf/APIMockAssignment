using System;

namespace CustomerOrderHistoryConsumer.BusinessObjects
{
    /// <summary>
    /// Represent the response from the API, when the API is hit, JSON will be deserialized to this object
    /// </summary>
    public class OrderHistoryItem
    {
        public string OrderNumber
        {
            get; set;
        }

        public DateTime OrderDate
        {
            get; set;
        }

        public string OrderStatus
        {
            get; set;
        }

        public OrderHistoryItem(string _orderNumber, DateTime _orderDate, string _orderStatus)
        {
            OrderDate = _orderDate;
            OrderNumber = _orderNumber;
            OrderStatus = _orderStatus;
        }
    }
}