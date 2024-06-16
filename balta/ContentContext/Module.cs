namespace Balta.ContentContext
{
  public class Module
  {
    public int Order { get; set; }
    public string Title { get; set; }
    public IList<Lecture> Lectures { get; set; } = new List<Lecture>();
  }
}