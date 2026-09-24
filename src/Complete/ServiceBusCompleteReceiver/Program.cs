using Azure.Messaging.ServiceBus;

string connectionString = "";
string queueName = "";

// Create Service bus client

ServiceBusClient serviceBusClient=new ServiceBusClient(connectionString);


// Create Service Buse Reciver

ServiceBusReceiver serviceBusReceiver=serviceBusClient.CreateReceiver(queueName);

// receive the message 

ServiceBusReceivedMessage msg =await serviceBusReceiver.ReceiveMessageAsync();

// lets complete the mesage

await serviceBusReceiver.CompleteMessageAsync(msg);

Console.WriteLine("The Receive message has been completed");
