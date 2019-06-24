using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using LiveArt.ProductsManagement.Database.Install.Migrations;

namespace LiveArt.ProductsManagement.Database.Install
{
    public static class MigrationsRunner
    {
        private class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public string ProviderSwitches { get; set; }
            public int? Timeout { get; set; }
        }

        public static void MigrateToLatestVersion(string connectionString)
        {
            MigrateUp(connectionString, null);
        }

        public static void MigrateUp(string connectionString, long? migrationId)
        {
            var announcer = GetAnnouncer();
            var assembly = Assembly.GetAssembly(typeof(Seed));

            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = typeof(Seed).Namespace
            };

            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60, ProviderSwitches = null };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                if (migrationId.HasValue)
                {
                    runner.MigrateUp(migrationId.Value, true);
                }
                else
                {
                    runner.MigrateUp(true);
                }
            }
        }

        public static void MigrateDownToCleanDb(string connectionString)
        {
            MigrateDown(connectionString, null);
        }

        public static void MigrateDown(string connectionString, long? migrationId)
        {
            var announcer = GetAnnouncer();
            var assembly = Assembly.GetAssembly(typeof(Seed));

            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = typeof(Seed).Namespace
            };

            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                if (migrationId.HasValue)
                {
                    runner.RollbackToVersion(migrationId.Value);
                }
                else
                {
                    runner.Rollback(int.MaxValue);
                }
            }
        }

        private static Announcer GetAnnouncer()
        {
            return new NullAnnouncer();
        }
    }
}
