using Dapper;
using Microsoft.Extensions.Configuration;
using Product.Data.Abstracts;
using Product.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Data.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(ProductEntity entity)
        {
            var sql = "Insert into Products (Name,Description,Category,Price) VALUES (@Name,@Description,@Category,@Price)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }

        }
        public async Task<List<ProductEntity>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductEntity>(sql);
                return result.ToList();
            }
        }


        public async Task<ProductEntity> GetAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<ProductEntity>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> Update(ProductEntity entity)
        {
            var sql = "UPDATE Products SET Name = @Name, Description = @Description, Category = @Category, Price = @Price  WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
