using BaltaDataAccess.Category;
using Dapper;
using Microsoft.Data.SqlClient;

const string stringConnection = "Server=localhost,1433;Database=balta;User ID=sa;Password=10096577Ss.;TrustServerCertificate=True";

using (SqlConnection connection = new SqlConnection(stringConnection))
{

  // Console.WriteLine("Connected...");

  // using (SqlCommand command = new SqlCommand())
  // {
  //   connection.Open();

  //   command.Connection = connection;
  //   command.CommandType = System.Data.CommandType.Text;
  //   command.CommandText = "SELECT [Id], [Title] FROM [Category]";

  //   var reader = command.ExecuteReader();
  //   while (reader.Read())
  //   {
  //     Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
  //   }
  // }


  IEnumerable<Category> categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

  foreach (Category category in categories)
  {
    Console.WriteLine($"Id: {category.Id} - Title: {category.Title}");
  }
}

