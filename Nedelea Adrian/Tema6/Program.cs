namespace Tema6
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    // using Microsoft.Azure.ServiceBus;

    class Program
    {
        static void Main(string[] args)
        {
            const string ServiceBusConnectionString = "Endpoint=sb://datc6service.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=AnuBho0NADDIgrxYbfTUb6XGebnx6VgBa0usT4geTKE=";

            const string QueueName = "coada";

            static IQueueClient queueClient;

            public static async Task Main(string[] args)
            {
                const int numberpfMessage = 10;
                queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
                Console.WriteLine("================================================");
                Console.WriteLine("Press ENTER key to exit afetr sending all message");
                Console.WriteLine("================================================");

                await SendMessageAsync(numberOfMessages);
                Console.ReadKey();

                await queueClient.CloseAsync();
            }

            static async Task SendMessageAsync(int numberOfMessagesToSend)
            {
                try
                {
                    for (var i = 0; i < numberOfMessagesToSend; i++)
                    {
                        string messageBody = $"hello,world:{i}";
                        var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                        Console.WriteLine($"Sending message:{messageBody}");

                        await queueClient.SendAsync(message);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now}::Exeption:{exception.Message}");
                }
            }
        }
    }
}

