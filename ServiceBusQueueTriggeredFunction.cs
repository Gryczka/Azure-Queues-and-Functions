//Azure Service Bus Queue Trigger for Azure Function Example
//From: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-service-bus-trigger
//Triggers on Message hitting a Queue.
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace QueueTrigger.Function
{
    public static class ServiceBusQueueTriggeredFunction
    {
        const string ServiceBusConnectionString = "<replace-with-your-queue's-connection-string>";
        const string QueueName = "<replace-with-your-queue's-name>";    
        
        [FunctionName("ServiceBusQueueTriggerCSharp")]       
        public static void Run(
            [ServiceBusTrigger(QueueName, Connection = ServiceBusConnectionString)] 
            string myQueueItem,
            Int32 deliveryCount,
            DateTime enqueuedTimeUtc,
            string messageId,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");
        }
    }
}