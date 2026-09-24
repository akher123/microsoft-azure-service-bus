using Azure.Messaging.ServiceBus;

string connectionString = "";
string queueName = "";

//Create Service bus client

ServiceBusClient serviceBusClient=new ServiceBusClient(connectionString);

// Service bus receiver

ServiceBusReceiver serviceBusReceiver= serviceBusClient.CreateReceiver(queueName);

// Recive the message

ServiceBusReceivedMessage msg= await serviceBusReceiver.ReceiveMessageAsync();

// Lets abandon the message
await serviceBusReceiver.AbandonMessageAsync(msg);

Console.WriteLine("Mesagge operation completed");
