using ASPCoreFirstApp.Models;
using System.Data.SqlClient;

namespace ASPCoreFirstApp.Services
{
    public class ProductsDAO : IProductsDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<ProductModel> AllProducts()
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement = "SELECT * FROM dbo.Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundProducts;
        }

        public bool Delete(int productId)
        {
            //Returns -1 if update fails
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlStatement = "Delete from dbo.Products Where Id = @Id";

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                
                command.Parameters.AddWithValue("@Id", productId);
                try
                {
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(!reader.HasRows)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            return true;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel foundProduct = null;

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProduct = new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundProduct;
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement = "SELECT * FROM dbo.Products where Name LIKE @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Name", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel((int)reader[0], (string)reader[1], (decimal)reader[2], (string)reader[3]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundProducts;
        }

        public int Update(ProductModel product)
        {
            //Returns -1 if update fails
            int newIDNumber = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlStatement = "Update dbo.Products set Name = @Name, Price = @Price, Description = @Description where Id = @Id";

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Description", product.Description);

                try
                {
                    connection.Open();
                    newIDNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            return newIDNumber;
        }
    }
}
