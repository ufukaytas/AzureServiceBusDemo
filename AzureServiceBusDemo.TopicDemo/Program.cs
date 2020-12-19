using AzureServiceBusDemo.TopicDemo.Service;
using Microsoft.Azure.ServiceBus;
using System;
using System.Threading.Tasks;

namespace AzureServiceBusDemo.TopicDemo
{
    class Program
    {

        private static string serviceBusConnection = "<< Add Service Bus Connection String Here >>";
        private static string topicName = "ordernotificationtopic";
        private static string subscriptionName1 = "emailsender";
        private static string subscriptionName2 = "smssender";
        static async  Task Main(string[] args)
        {
            // Send Order Information To Topic
            await OrderTopicSender.SendMessageAsync(serviceBusConnection, topicName);

            // Receive Order Information From Topic

            // First Subscriber
            await OrderTopicReceiver.ReceiveMessageAsync(serviceBusConnection, topicName, subscriptionName1);

            // Second Subscriber
            await OrderTopicReceiver.ReceiveMessageAsync(serviceBusConnection, topicName, subscriptionName2);
        }
    }
}
