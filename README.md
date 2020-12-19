# Azure Service Bus Queue and Topic Demo


# Project Overview:

The solution consists of two console applications AzureServiceBusDemo.QueueDemo and AzureServiceBusDemo.TopicDemo

`QueueDemo` console application to send and receive messages to the Azure Service Bus queue.

`TopicDemo` console application to send messages to Azure Service Bus Topic and receive with more than one Subscriber.

The Recievers pulls active messages from the Azure Service Bus Queue and Topic and prints the to the console.

# Prerequisites

* Azure Subscription with Azure Service Bus Queue.
* ASP.NET Core 3.1

# Requires
1. Connection string to the Azure Service Bus should have Listen-and-Write access role for an existing Azure Service Bus Queue.
2. You need to create a queue to send and receive messages with Queue. A sample queue named "orderqueue" has been created for the application.
3. To send and receive messages with Topic, you have to create one topic. I created a topic called "ordernotificationtopic" for the application. You also need to define subscriptions. Two subscriptions named emailsender and smsmsender were created for the application.
