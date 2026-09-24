using Azure.Messaging.ServiceBus;

string connectionString = "";
string queueName = "";

//Create Service bus client

ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);

// Service bus receiver

ServiceBusReceiver serviceBusReceiver = serviceBusClient.CreateReceiver(queueName);

// Recive the message

ServiceBusReceivedMessage msg = await serviceBusReceiver.ReceiveMessageAsync();

// Lets deferred the message
await serviceBusReceiver.DeferMessageAsync(msg);
// Lets read defeered message
int sequancenumber = 16;
var defeeredMessage= await serviceBusReceiver.ReceiveDeferredMessageAsync(sequancenumber);

Console.WriteLine("Mesagge operation completed");
