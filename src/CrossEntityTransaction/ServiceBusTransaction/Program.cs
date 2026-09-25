using Azure.Messaging.ServiceBus;
using System.Transactions;

Console.WriteLine("Hello, World!");

string connectionString = "";

string queue_1 = "queue_1";
string queue_2 = "queue_2";
string queue_3 = "queue_3";

// Create service bus client and set cross entity transaction= true
var serviceBusClient=new ServiceBusClient(connectionString,new ServiceBusClientOptions()
{
    EnableCrossEntityTransactions = true
});

// Create a receiver fro Queue_1
var serviceBusReceiver_1=serviceBusClient.CreateReceiver(queue_1);
// Create a sender fro Queue_2
var serviceBusSender_2= serviceBusClient.CreateSender(queue_2);
// Create a sender fro Queue_3
var serviceBusSender_3 = serviceBusClient.CreateSender(queue_3);
// Now Lets read message from queue_1 first
var msagReceive=await serviceBusReceiver_1.ReceiveMessageAsync();
// Lets begin transaction - Here write message to queue_2 and queue_3 and then complete message in queue_1
using( var trn=new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
{
    await serviceBusSender_2.SendMessageAsync(new ServiceBusMessage(msagReceive.Body.ToString()));
    await serviceBusSender_3.SendMessageAsync(new ServiceBusMessage(msagReceive.Body.ToString()));
    await serviceBusReceiver_1.CompleteMessageAsync(msagReceive);

    trn.Complete();
}
Console.WriteLine("Transaction completed/Rolled-backe");