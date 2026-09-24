using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using ServiceBusObjectSender;
using System.Text;

Console.WriteLine("Hello, World!");
string connectionString = "";
string queueName = "";

// Create Client with the connectionstring
ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
// Create service bus Sender
ServiceBusSender serviceBusSender=serviceBusClient.CreateSender(queueName);

// Send the message using service bus sender
Employee employee = Employee.Create("Md", "Akheruzzaman", 20000);
var employeInJson= JsonConvert.SerializeObject(employee); 
ServiceBusMessage message = new(Encoding.UTF8.GetBytes(employeInJson));

await serviceBusSender.SendMessageAsync(message);

Console.WriteLine("Message has been sent...");

