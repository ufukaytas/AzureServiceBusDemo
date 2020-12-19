using AzureServiceBusDemo.QueueDemo.Model;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureServiceBusDemo.QueueDemo.Service
{
    public static class OrderReceiver
    {
        private static IQueueClient client;
        public static async Task ReceiveOrderInformationFromQueueAsync(string serviceBusConn, string queueName)
        {
            await Task.Factory.StartNew(() =>
            {
                client = new QueueClient(serviceBusConn, queueName);
                var options = new MessageHandlerOptions(ExceptionMethod)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };
                client.RegisterMessageHandler(ExecuteMessageProcessing, options);
            });
            Console.Read();
        }

        private static async Task ExecuteMessageProcessing(Message message, CancellationToken arg2)
        {
            var result = JsonConvert.DeserializeObject<OrderInfo>(Encoding.UTF8.GetString(message.Body));
            Console.WriteLine($"Order Id is {result.Id}, Order name is {result.Name} and quantity is {result.Quantity}");
            await client.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static async Task ExceptionMethod(ExceptionReceivedEventArgs arg)
        {
            await Task.Run(() =>
           Console.WriteLine($"Error occured. Error is {arg.Exception.Message}")
           );
        }
    }
}
