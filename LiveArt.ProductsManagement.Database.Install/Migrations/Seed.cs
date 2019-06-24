using FluentMigrator;

namespace LiveArt.ProductsManagement.Database.Install.Migrations
{
    [Maintenance(MigrationStage.AfterAll)]
    public class Seed : Migration
    {
        public override void Down()
        {
        }

        public override void Up()
        {
            Execute.Sql(SqlScriptResources.setup_product_save_sp);
            Execute.Sql(SqlScriptResources.setup_comment_save_sp);
        }
    }
}
