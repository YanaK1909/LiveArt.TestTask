using FluentMigrator;

namespace LiveArt.ProductsManagement.Database.Install.Migrations
{
    [Migration(1)]
    public class _1_SetupProductsWithComments : Migration
    {
        public override void Down()
        {
            Delete.Table("Comment");
            Delete.Table("Product");
        }

        public override void Up()
        {
            this.CreateProductTable();
            this.CreateCommentTable();
        }

        private void CreateProductTable()
        {
            Create.Table("Product").InSchema("dbo")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("Description").AsString(4000)
                .WithColumn("ThumbnailImage").AsCustom("nvarchar(max)");
        }

        private void CreateCommentTable()
        {
            Create.Table("Comment").InSchema("dbo")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("ProductId").AsInt32().NotNullable().ForeignKey("CommentToProduct", "Product", "Id").Indexed()
                .WithColumn("Author").AsString(200).NotNullable()
                .WithColumn("Message").AsString(4000);
        }
    }
}
