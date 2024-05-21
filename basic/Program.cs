class Program
{
  private static void Main(string[] args)
  {
    Product Computer = new Product("computer", 5000, EProductCategory.Eletronic);

    Console.WriteLine(Computer.ProductName);
    Console.WriteLine(Computer.Price);
    Console.WriteLine(Computer.Category);
  }
}

struct Product
{
  public string ProductName { get; }
  public int Price { get; }
  public EProductCategory Category { get; }

  public Product(string productName, int price, EProductCategory category)

  {
    ProductName = productName;
    Price = price;
    Category = category;
  }

  public void PrintProductName()
  {
    Console.WriteLine(ProductName);
  }
}

enum EProductCategory
{
  Eletronic = 1,
  Furniture = 2,
  Food = 3,
}
