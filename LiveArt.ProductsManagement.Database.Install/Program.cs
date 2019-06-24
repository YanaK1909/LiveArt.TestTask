using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace LiveArt.ProductsManagement.Database.Install
{
    class Program
    {
        static void Main(string[] args)
        {
            var arg = string.Empty;

            if (args.Length == 0)
            {
                var commandsMessage = "Specify one of the following parameters:\n" +
                    "-i     - install all migrations\n" +
                    "-u     - uninstall all migrations\n" +
                    "-ui    - uninstall and install all migrations";

                Console.WriteLine(commandsMessage);
                arg = Console.ReadLine();
            }
            else
            {
                arg = args[0];
            }

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("ProductsManagement");

            switch (arg)
            {
                case "-i":
                    MigrationsRunner.MigrateUp(connectionString, null);
                    break;
                case "-u":
                    MigrationsRunner.MigrateDown(connectionString, null);
                    break;
                case "-ui":
                    MigrationsRunner.MigrateDownToCleanDb(connectionString);
                    MigrationsRunner.MigrateToLatestVersion(connectionString);
                    break;
            }
        }
    }
}
