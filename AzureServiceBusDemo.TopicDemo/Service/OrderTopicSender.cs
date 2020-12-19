using AzureServiceBusDemo.TopicDemo.Model;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceBusDemo.TopicDemo.Service
{
    public static class OrderTopicSender
    {
        static ITopicClient topicClient;
        public static async Task SendMessageAsync(string serviceBusConn, string topicName)
        {
            List<OrderInfo> listOrderInfos = new List<OrderInfo>
            {
                new OrderInfo { Id = 1, Name = "Hamburger", Price = 40, Quantity = 1 },
                new OrderInfo { Id = 1, Name = "Pizza", Price = 100, Quantity = 3 }
            };

            topicClient = new TopicClient(serviceBusConn, topicName);

            foreach (var item in listOrderInfos)
            {
                var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item)));

                await topicClient.SendAsync(message);

                Console.WriteLine($"Sending Message : {item.Name} ");
            }

            
        }
    }
}
