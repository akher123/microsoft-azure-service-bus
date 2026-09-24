using Azure.Messaging.ServiceBus;

string connectionString = "";
string queueName = "";

//Create Service bus client
ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
// Create service Reciver 
ServiceBusReceiver serviceBusReceiver=serviceBusClient.CreateReceiver(queueName);

// Receive the message 

ServiceBusReceivedMessage msg = await serviceBusReceiver.ReceiveMessageAsync();

Console.WriteLine("Message has been recieved...");