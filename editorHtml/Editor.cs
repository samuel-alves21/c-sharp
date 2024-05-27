using System.Text;

namespace EditorHtml
{
  public static class Editor
  {
    public static void Show()
    {
      Console.Clear();
      Console.WriteLine("EDITOR MODE");
      Console.WriteLine("+----------+");

      Start();
    }

    public static void Start()
    {
      var file = new StringBuilder();

      do
      {
        file.Append(Console.ReadLine());
        file.AppendLine(Environment.NewLine);
      } while (Console.ReadKey().Key != ConsoleKey.Escape);

      Console.WriteLine(" +----------+");
      Console.Write("  Do you wanna save the file? s/n: ");
      char option = Console.ReadKey().KeyChar;

      Console.WriteLine("");
      Console.WriteLine("");

      HandleSave(option, file.ToString());

      Viewer.Show(file.ToString());
    }

    public static void HandleSave(char option, string file)
    {
      if (option != 's') return;

      Console.Write("Digit the path you wanna save it: ");
      Console.WriteLine("");
      string? path = Console.ReadLine();

      if (path == null) return;

      using (var fs = new StreamWriter(path))
      {
        fs.Write(file);
      }

      Console.WriteLine("");
      Console.WriteLine($"File saved successfuly at {path}");
    }
  }
}