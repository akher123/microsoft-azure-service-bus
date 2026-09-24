using Azure.Messaging.ServiceBus;
string connectionString = "";
string queueName = "";

// Create service bus client
ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
// create service bus sender
ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(queueName);
// send message using service bus sender

ServiceBusMessage serviceBusMessage = new ServiceBusMessage("Hello from C# visual studio...");

await serviceBusSender.SendMessageAsync(serviceBusMessage) ;
Console.WriteLine("Message has been sent");