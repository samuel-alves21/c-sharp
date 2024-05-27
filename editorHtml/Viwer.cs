using System.Text.RegularExpressions;

namespace EditorHtml
{
  static public class Viewer
  {

    public static void Show(string text)
    {
      Console.Clear();
      Console.WriteLine("VIWER MODE");
      Console.WriteLine("+----------+");

      Start(text);

      Console.WriteLine("");
      Console.WriteLine("+----------+");
      Console.WriteLine("Press Something to return back to the menu");
      Console.ReadKey();

      Menu.Show();
    }

    public static void Start(string text)
    {
      Regex strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");

      var words = text.Split(' ');
      for (var i = 0; i < words.Length; i++)
      {
        if (strong.IsMatch(words[i]))
        {
          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write(
              words[i].Substring(
                  words[i].IndexOf('>') + 1,
                  words[i].LastIndexOf('<') - 1 - words[i].IndexOf('>')
              )
          );
          Console.Write(" ");
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.White;
          Console.Write(words[i]);
          Console.Write(" ");
        }
      }
    }
  }
}