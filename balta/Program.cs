using Balta.ContentContext;
using Balta.ContentContext.Enums;

Console.Clear();

Course aspnetCourse = new Course("ASP.NET fundamentals", "apsnet-fundamentals", EContentLevel.Fundamental);
Course cSharpCourse = new Course("C# fundamentals", "csharp-fundamentals", EContentLevel.Fundamental);
Course oopCourse = new Course("OOP fundamentals", "oop-fundamentals", EContentLevel.Fundamental);

List<Course> CourseList = [aspnetCourse, cSharpCourse, oopCourse];

var carrerDotNet = new Carrer("C# specialist", "csharp-specialist");
var CarrerItem2 = new CarrerItem(2, "OOP", "", oopCourse);
var CarrerItem = new CarrerItem(1, "start here", "", cSharpCourse);
var CarrerItem3 = new CarrerItem(3, ".NET", "", aspnetCourse);
carrerDotNet.Items.Add(CarrerItem2);
carrerDotNet.Items.Add(CarrerItem);
carrerDotNet.Items.Add(CarrerItem3);

List<Carrer> carrers = [carrerDotNet];

foreach (var carrer in carrers)
{
  Console.WriteLine(carrer.Title);
  foreach (var item in carrer.Items)
  {
    Console.WriteLine($"{item.Order}-{item.Title}");
  }
}