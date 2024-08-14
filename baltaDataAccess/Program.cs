using BaltaDataAccess.Category;
using Dapper;
using Microsoft.Data.SqlClient;

const string stringConnection = "Server=localhost,1433;Database=balta;User ID=sa;Password=10096577Ss.;TrustServerCertificate=True";

using (SqlConnection connection = new SqlConnection(stringConnection))
{
  // UpdateCategory(connection);
  ListCategories(connection);
  // CreateCategory(connection);
}

static void ListCategories(SqlConnection connection)
{
  IEnumerable<Category> categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

  foreach (Category item in categories)
  {
    Console.WriteLine($"Id: {item.Id} - Title: {item.Title}");
  }
}

static void UpdateCategory(SqlConnection connection)
{

  const string updateSql = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";

  var rows = connection.Execute(
    updateSql,
    new
    {
      Id = "af3407aa-11ae-4621-a2ef-2028b85507c4",
      Title = "Backend C#"
    }
  );

  Console.WriteLine($"{rows} row(s) updated");
}

static void CreateCategory(SqlConnection connection)
{

  Category category = new Category
  {
    Id = Guid.NewGuid(),
    Title = "Backend",
    Url = "backend",
    Summary = "Sumario do backend",
    Order = 1,
    Description = "Descrição do backend",
    Featured = false
  };

  const string insertSql = "INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

  var rows = connection.Execute(
    insertSql,
    new
    {
      category.Id,
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured
    }
  );

  Console.WriteLine($"{rows} row(s) inserted");
}