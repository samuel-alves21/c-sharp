namespace Balta.ContentContext
{
  public class CarrerItem(int order, string title, string description, Course course)
  {
    public int Order { get; set; } = order;
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public Course Course { get; set; } = course;
  }
}
