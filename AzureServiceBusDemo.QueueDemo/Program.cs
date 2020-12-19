using AzureServiceBusDemo.QueueDemo.Service;
using System;
using System.Threading.Tasks;

namespace AzureServiceBusDemo.QueueDemo
{
    class Program
    {
        private static string serviceBusConnection = "<< Add Service Bus Connection String Here >>";
        private static string queueName = "orderqueue";

        static async Task Main(string[] args)
        {
            // Send Order Information To Queue
            await OrderSender.SendOrderInformationToQueueAsync(serviceBusConnection, queueName);

            // Receive Order Information To Queue
            await OrderReceiver.ReceiveOrderInformationFromQueueAsync(serviceBusConnection, queueName);
        }
    }
}
