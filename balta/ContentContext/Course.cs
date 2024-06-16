using Balta.ContentContext.Enums;

namespace Balta.ContentContext
{
  public class Course(string title, string url, EContentLevel level) : Content(title, url)
  {
    public string Tag { get; set; }
    public IList<Module> Modules { get; set; } = new List<Module>();
    public EContentLevel Level { get; set; } = level;
  }
}

