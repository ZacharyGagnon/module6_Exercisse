using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DSED_Module6_DAL_SQLServer
{
    public class Configuration
    {

        private static IConfigurationRoot m_configuration;
        private static IConfigurationRoot Settings
        {
            get
            {
                if (m_configuration == null)
                {
                    m_configuration =
                    new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", false)
                    .Build();
                }

                return m_configuration;
            }
        }

        public static string ChaineConnection
        {
            get
            {
                return Settings.GetConnectionString("DefaultConnection");
            }
        }
    }
}