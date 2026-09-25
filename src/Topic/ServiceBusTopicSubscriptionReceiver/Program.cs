// lets install required nuget package
// lets use the package
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

// connection string to connect to service bus topic

string connectionString = "";
string topicName = "firsttopic";
string subscriptionName = "S1";

// Lets create service bus client

var serviceBusClient = new ServiceBusClient(connectionString);
// Create service bus receiver
var serviceBusReceiver=serviceBusClient.CreateReceiver(topicName,subscriptionName);

// Lets actually read the message from subscription in  that topics

var message=await serviceBusReceiver.ReceiveMessageAsync();

Console.WriteLine("Message has been successfully read from subscriptions..");


