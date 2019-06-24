using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LiveArt.ProductsManagement.Domain.Contracts.Repositories;
using LiveArt.ProductsManagement.Domain.Contracts.Services;
using LiveArt.ProductsManagement.Domain.Entities;

namespace LiveArt.ProductsManagement.Domain.Repositories
{
    public class ProductRepository : IRepositoryBase<Product>
    {
        private readonly string connectionString;
        private readonly ICommentRepository commentRepository;

        public ProductRepository(IConnectionStringProvider connectionStringProvider, ICommentRepository commentRepository)
        {
            this.connectionString = connectionStringProvider.ConnectionString;
            this.commentRepository = commentRepository;
        }

        public void AddOrUpdate(Product entity)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                db.Execute(
                    "SaveProduct",
                    entity,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            commentRepository.DeleteByProductId(id);

            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                db.Execute(
                    "DELETE FROM Product WHERE Id = @id",
                    new { id });
            }
        }

        public Product Get(int id)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                string sql = "SELECT * FROM Product WHERE Id = @id;";

                return db.QuerySingleOrDefault<Product>(
                    sql,
                    new { id });
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                string sql = "SELECT * FROM Product;";

                return db.Query<Product>(
                    sql);
            }
        }
    }
}
