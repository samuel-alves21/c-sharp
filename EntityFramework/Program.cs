using EntityFramework.Data;
using EntityFramework.Models;

using (BlogDataContext context = new BlogDataContext())
{
  // CREATE

  // Tag tag = new Tag { Name = "ASP-NET", Slug = "aspnet" };
  // context.Tags.Add(tag);
  // context.SaveChanges();


  // context.Tags.Add(new Tag { Name = ".NET", Slug = "dotnet" });
  // context.SaveChanges();

  //UPDATE

  // Tag tag = context.Tags.FirstOrDefault(x => x.Id == 5);
  // tag.Name = "ASP.NET Core";
  // tag.Slug = "aspnetcore";
  // context.Tags.Update(tag);
  // context.SaveChanges();

  //DELETE

  // Tag tag = context.Tags.FirstOrDefault(x => x.Id == 5);
  // context.Tags.Remove(tag);
  // context.SaveChanges();

  //READ

  List<Tag> tags = context.Tags.Where(x => x.Name == ".NET" || x.Name == "ASP-NET").ToList();

  foreach (var tag in tags)
  {
    Console.WriteLine(tag.Name);
  }
}