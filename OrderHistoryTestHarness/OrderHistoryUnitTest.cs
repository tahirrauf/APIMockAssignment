using NUnit.Framework;
using Moq;
using CustomerOrderHistoryConsumer.BusinessObjects;
using CustomerOrderHistoryConsumer.Services;
using System.Collections.Generic;
using System;
using CustomerOrderHistoryConsumer;

namespace OrderHistoryTestHarness
{
    public class Tests
    {
        private Mock<IOrderHistoryService> orderHistoryServiceMock;        

        [SetUp]
        public void Setup()
        {
            orderHistoryServiceMock = new Mock<IOrderHistoryService>();

            List<OrderHistoryItem> emptyOrderHistoryList = new List<OrderHistoryItem>();
            orderHistoryServiceMock.Setup(p => p.GetOrderHistory("123")).Returns(emptyOrderHistoryList);

            List<OrderHistoryItem> singleHistoryItem = new List<OrderHistoryItem>();
            singleHistoryItem.Add(new OrderHistoryItem("1", DateTime.Now, "New"));
            orderHistoryServiceMock.Setup(p => p.GetOrderHistory("234")).Returns(singleHistoryItem);

            List<OrderHistoryItem> multipleHistoryItem = new List<OrderHistoryItem>();
            multipleHistoryItem.Add(new OrderHistoryItem("1", DateTime.Now, "New"));
            multipleHistoryItem.Add(new OrderHistoryItem("2", DateTime.Now, "Cancelled"));
            multipleHistoryItem.Add(new OrderHistoryItem("3", DateTime.Now, "New"));
            multipleHistoryItem.Add(new OrderHistoryItem("4", DateTime.Now, "DeadOnArrival"));
            orderHistoryServiceMock.Setup(p => p.GetOrderHistory("456")).Returns(singleHistoryItem);

            orderHistoryServiceMock.Setup(p => p.GetOrderHistory(null)).Throws(new ArgumentNullException());
        }

        [Test]
        public void ShouldReturnNOHistoryItem()
        {
            APIConsumer apiConsumerObject = new APIConsumer(orderHistoryServiceMock.Object);
            Assert.AreEqual(apiConsumerObject.GetCustomerOrderHistory("123").Count, 0);           
        }

        [Test]
        public void ShouldReturnSingleHistoryItem()
        {
            APIConsumer apiConsumerObject = new APIConsumer(orderHistoryServiceMock.Object);
            Assert.AreEqual(apiConsumerObject.GetCustomerOrderHistory("234").Count, 1);
        }

        [Test]
        
        public void ShouldThrowArgumentException()
        {          
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(CallApiWithException));
        }

        /// <summary>
        /// A method that demonstrate invalid API parameters, which will return the NullArgumentException
        /// </summary>
        public void CallApiWithException()
        {
            APIConsumer apiConsumerObject = new APIConsumer(orderHistoryServiceMock.Object);
            apiConsumerObject.GetCustomerOrderHistory(null);
        }

        
    }
}