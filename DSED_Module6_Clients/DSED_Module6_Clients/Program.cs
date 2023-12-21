using M06_CasUtlisation_Clients;
using M06_MessageClient;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace DSED_Module6_Clients
{
    public class Program
    {
        private static ManualResetEvent waitHandle = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            MessageClient client = new MessageClient();
            Console.WriteLine("entre le nom du nouveau client : ");
            client.Nom = Console.ReadLine();
            Console.WriteLine("entre le prenom du nouveau client : ");
            client.Prenom = Console.ReadLine();
            Console.WriteLine("entre le courriel du nouveau client : ");
            client.Courriel = Console.ReadLine();
            Console.WriteLine("entre le numero de telephone du nouveau client : ");
            client.NumeroTelephone = Console.ReadLine();
            EnveloppeClient enveloppeClient = new EnveloppeClient("Create", "1", client);
            string jsonClient = Newtonsoft.Json.JsonConvert.SerializeObject(enveloppeClient);
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connexion = factory.CreateConnection())
            {
                using (IModel channel = connexion.CreateModel())
                {
                    channel.QueueDeclare(queue: "client",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                    byte[] body = Encoding.UTF8.GetBytes(jsonClient);

                    channel.BasicPublish(exchange: "", routingKey: "client", body: body);
       
                }

            }
        }
    }
}