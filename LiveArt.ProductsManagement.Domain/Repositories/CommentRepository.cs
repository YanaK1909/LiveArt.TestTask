using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LiveArt.ProductsManagement.Domain.Contracts.Repositories;
using LiveArt.ProductsManagement.Domain.Contracts.Services;
using LiveArt.ProductsManagement.Domain.Entities;

namespace LiveArt.ProductsManagement.Domain.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly string connectionString;

        public CommentRepository(IConnectionStringProvider connectionStringProvider)
        {
            this.connectionString = connectionStringProvider.ConnectionString;
        }

        public void AddOrUpdate(Comment entity)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                db.Execute(
                    "SaveComment",
                    entity,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                db.Execute(
                    "DELETE FROM Comment WHERE Id = @id",
                    new { id });
            }
        }

        public void DeleteByProductId(int productId)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                db.Execute(
                    "DELETE FROM Comment WHERE ProductId = @productId",
                    new { productId });
            }
        }

        public Comment Get(int id)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                string sql = "SELECT * FROM Comment WHERE Id = @id;";

                return db.QuerySingleOrDefault<Comment>(
                    sql,
                    new { id });
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                string sql = "SELECT * FROM Comment;";

                return db.Query<Comment>(
                    sql);
            }
        }

        public IEnumerable<Comment> GetByProductId(int productId)
        {
            using (IDbConnection db = new SqlConnection(this.connectionString))
            {
                string sql = "SELECT * FROM Comment WHERE ProductId = @productId;";

                return db.Query<Comment>(
                    sql,
                    new { productId });
            }
        }
    }
}
