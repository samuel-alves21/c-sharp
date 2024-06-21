namespace BaltaDataAccess.Category
{
  public class Category
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = "";
    public string Url { get; set; } = "";
    public string Summary { get; set; } = "";
    public int Order { get; set; } = 0;
    public string Description { get; set; } = "";
    public bool Featured { get; set; } = false;
  }
}