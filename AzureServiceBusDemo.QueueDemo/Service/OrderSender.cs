using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureServiceBusDemo.QueueDemo.Model;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace AzureServiceBusDemo.QueueDemo.Service
{
    public static class OrderSender
    { 
        public static async  Task SendOrderInformationToQueueAsync(string serviceBusConn, string queueName)
        {
            List<OrderInfo> listOrderInfos = new List<OrderInfo>
            {
                new OrderInfo { Id = 1, Name = "Hamburger", Price = 40, Quantity = 1 },
                new OrderInfo { Id = 1, Name = "Pizza", Price = 100, Quantity = 3 }
            };


            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            Console.ReadKey();

            IQueueClient client = new QueueClient(serviceBusConn, queueName);
            foreach (var item in listOrderInfos)
            {
                var messageBody = JsonConvert.SerializeObject(item);
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                await client.SendAsync(message);
                Console.WriteLine($"Sending Message : {item.Name} ");

            }


        }
    }
}
