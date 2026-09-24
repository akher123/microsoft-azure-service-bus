
using Azure.Messaging.ServiceBus;

string connectionString = "";
string queueName = "";

// Create Service buss client
ServiceBusClient serviceBusClient=new ServiceBusClient(connectionString); 

//Creat Service bus receiver in picklock mode

ServiceBusReceiver receiver=serviceBusClient.CreateReceiver(queueName,new ServiceBusReceiverOptions() { ReceiveMode=ServiceBusReceiveMode.PeekLock});
// if we read the object in Peeklock mode--> we receive the message but message is not deleted from the queue
var message= await receiver.ReceiveMessageAsync();
Console.WriteLine("We have received message in Peeklock mode...");

//Creat Service bus receiver in ReceivedAndDelete mode

ServiceBusReceiver receivedAndDelete = serviceBusClient.CreateReceiver(queueName, new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

var messageReceivedAndDelete=await receivedAndDelete.ReceiveMessageAsync();
// if we read the object in received and delete mode--> we receive the message but message is also deleted from the queue
Console.WriteLine("Hello, World!");
