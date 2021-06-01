namespace azurequeue
{
    using Azure.Storage.Queues;
    using Azure.Storage.Queues.Models;
    using System.Configuration;
    class Program
    {

        static void Main(string[] args)
        {
           
            // We'll need a connection string to your Azure Storage account.
            //string connectionString = ConfigurationManager.ConnectionStrings["storageaccount"]?.ConnectionString;
            string connectionString = ConfigurationManager.AppSettings["storageaccount"];
            // Name of the queue we'll send messages to
            string queueName = "az204queuejahohm";
            // Message enconding for base64
            var options = new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 };
            // Get a reference to a queue and then create it
            QueueClient queue = new QueueClient(connectionString, queueName, options);
            //queue.CreateAsync().Wait();

            // Send a message to our queue
            //queue.SendMessageAsync("Hello, Azure!").Wait();

            // Get the next messages from the queue
            foreach (QueueMessage message in queue.ReceiveMessages(maxMessages: 10)?.Value)
            {
                // "Process" the message
                System.Console.WriteLine($"Message: {message.Body}");
                
                // Let the service know we're finished with the message and
                // it can be safely deleted.
                //queue.DeleteMessage(message.MessageId, message.PopReceipt);
            }
            System.Console.WriteLine("Hello World!");
        }
    }
}
