namespace Balta.ContentContext
{
  public class Carrer : Content
  {
    public Carrer(string title, string url) : base(title, url)
    {
    }

    public IList<CarrerItem> Items { get; set; } = [];
    public int TotalCourses => Items.Count;
  }
}