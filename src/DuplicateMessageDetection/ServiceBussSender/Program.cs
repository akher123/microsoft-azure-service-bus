using Azure.Messaging.ServiceBus;

string connectionString = "";
string queueName = "";

// Create Service bus client
ServiceBusClient client = new ServiceBusClient(connectionString);
// Create servive bus sender
ServiceBusSender serviceBusSender = client.CreateSender(queueName);

// let us first create 2 message - with same contents, but we will not provide message-id

var messageContent = "Msg_Written_Twice";
var serviceBusMessage1 = new ServiceBusMessage(messageContent);
var serviceBusMessage2 = new ServiceBusMessage(messageContent);
await serviceBusSender.SendMessageAsync(serviceBusMessage1);
await serviceBusSender.SendMessageAsync(serviceBusMessage2);

Console.WriteLine("2 Separate message should be written in Queue");

// Again create 2 message - with same contents, but same message-id

var newMessageContent = "Msg_Written_only_Once";
var newServiceBusMessage1 = new ServiceBusMessage(newMessageContent);
newServiceBusMessage1.MessageId = "123456";

var newServiceBusMessage2 = new ServiceBusMessage(newMessageContent);
newServiceBusMessage2.MessageId = "123456";

await serviceBusSender.SendMessageAsync(newServiceBusMessage1);
await serviceBusSender.SendMessageAsync(newServiceBusMessage2);

Console.WriteLine("Only one message should be written in Queue");


