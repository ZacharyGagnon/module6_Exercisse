using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using DSED_Module6_DAL_SQLServer;
using DSED_Module6_Entite;

namespace DSED_module6_ConsommateurComptes
{
    public class Program
    {
        private static ManualResetEvent waitHandle = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<ContexteSQLServer> dbContextOptionsBuilder =
            new DbContextOptionsBuilder<ContexteSQLServer>();
            dbContextOptionsBuilder.UseSqlServer(DSED_Module6_DAL_SQLServer.Configuration.ChaineConnection)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
#if DEBUG
                            .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                            .EnableSensitiveDataLogging()
#endif
                            ;

            IDepotEntite depot = new DepotEntiteSQLServer(new ContexteSQLServer(dbContextOptionsBuilder.Options));

            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connexion = factory.CreateConnection())
            {
                using (IModel channel = connexion.CreateModel())
                {
                    channel.QueueDeclare(queue: "compte", durable: false, exclusive: false,
                    autoDelete: false, arguments: null
                    );

                    EventingBasicConsumer consommateur = new EventingBasicConsumer(channel);
                    consommateur.Received += (model, ea) =>
                    {
                        byte[] donnees = ea.Body.ToArray();
                        string jsonString = Encoding.UTF8.GetString(donnees);
                        Enveloppe enveloppeCompte = Newtonsoft.Json.JsonConvert.DeserializeObject<Enveloppe>(jsonString);
                        Compte compte = enveloppeCompte.Compte;
                        ManipulationEntite manipulationEntite = new ManipulationEntite(depot);
                        manipulationEntite.AjouterCompte(compte);
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