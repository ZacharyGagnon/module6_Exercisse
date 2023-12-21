using M06_CasUtlisation_Clients;
using M06_DAL_Client_SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Renci.SshNet.Messages;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using M06_MessageClient;

namespace M06_Clients_Consommateur
{
    public class Program
    {
        private static ManualResetEvent waitHandle = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<ClientContexteSQLServer> dbContextOptionsBuilder =
            new DbContextOptionsBuilder<ClientContexteSQLServer>();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ChaineConnection)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
#if DEBUG
                            .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                            .EnableSensitiveDataLogging()
#endif
                            ;

            IDepotClients depotClients = new DepotClientSQLServer(new ClientContexteSQLServer(dbContextOptionsBuilder.Options));

            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connexion = factory.CreateConnection())
            {
                using (IModel channel = connexion.CreateModel())
                {
                    channel.QueueDeclare(queue: "client", durable: false, exclusive: false,
                    autoDelete: false, arguments: null
                    );

                    EventingBasicConsumer consommateur = new EventingBasicConsumer(channel);
                    consommateur.Received += (model, ea) =>
                    {
                        byte[] donnees = ea.Body.ToArray();
                        string jsonString = Encoding.UTF8.GetString(donnees);
                        EnveloppeClient enveloppeClient = Newtonsoft.Json.JsonConvert.DeserializeObject<EnveloppeClient>(jsonString);
                        MessageClient messageClient = enveloppeClient.MessageClient;
                        Client client = new Client(new Guid(), messageClient.Nom, messageClient.Prenom, messageClient.Courriel, messageClient.NumeroTelephone);
                        ManipulationsClient manipulationsClient = new ManipulationsClient(depotClients);
                        manipulationsClient.AjouterClient(client);
                        channel.BasicAck(ea.DeliveryTag, false);
                    };
                    channel.BasicConsume(queue: "client",
                    autoAck: false,
                    consumer: consommateur
                    );
                    waitHandle.WaitOne();
                }
            }
        }
    }
}