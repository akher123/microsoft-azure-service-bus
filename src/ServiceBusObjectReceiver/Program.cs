using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using ServiceBusObjectReceiver;


string connectionString = "";
string queueName = "";

// Create Service bus client
ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
// Create service buss receiver

ServiceBusReceiver serviceBusReceiver= serviceBusClient.CreateReceiver(queueName);

// Try to read the mssage 

var  msg= await serviceBusReceiver.ReceiveMessageAsync();
var messageInJson= msg.Body.ToString();

// Late convert the message into Employee object using Desirialisation

Employee employee= JsonConvert.DeserializeObject<Employee>(messageInJson)!;

Console.WriteLine("Message Has been received successfully");