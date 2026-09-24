using Azure.Messaging.ServiceBus;

string connectionString = "";
string queueName = "";

//Create Service bus client

ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);

// Service bus receiver

ServiceBusReceiver serviceBusReceiver = serviceBusClient.CreateReceiver(queueName);

// Recive the message

ServiceBusReceivedMessage msg = await serviceBusReceiver.ReceiveMessageAsync();

// Lets deadletter the message
await serviceBusReceiver.DeadLetterMessageAsync(msg);
// Lets read message from deadletter queue

var reciveFromDeadLetterQueue= serviceBusClient.CreateReceiver(queueName, new ServiceBusReceiverOptions() { SubQueue=SubQueue.DeadLetter });
var msgObtainedFromDeadLetterQueue=await reciveFromDeadLetterQueue.ReceiveMessageAsync();

Console.WriteLine("Mesagge operation completed");
