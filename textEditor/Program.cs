Menu();

static void Menu()
{
  Console.Clear();
  Console.WriteLine("What do you want do do?");
  Console.WriteLine("1 - Open File");
  Console.WriteLine("2 - Edit File");
  Console.WriteLine("0 - Exit");

  short option = Convert.ToInt16(Console.ReadLine());

  switch (option)
  {
    case 1:
      OpenFile();
      break;
    case 2:
      EditFile();
      break;
    case 0:
      Environment.Exit(0);
      break;
    default:
      Menu();
      break;
  }
}

static void OpenFile()
{
  Console.Clear();
  Console.WriteLine("Digit your path...");

  string? path = Console.ReadLine();

  if (path == null) return;

  using (var fs = new StreamReader(path))
  {
    string text = fs.ReadToEnd();
    Console.Write(text);
  }

  Console.ReadLine();

  Menu();
}

static void EditFile()
{
  Console.Clear();
  Console.WriteLine("Digit your text (ESC to Escape)");
  Console.WriteLine("----------------");

  string text = "";

  do
  {
    text += Console.ReadLine();
    text += Environment.NewLine;
  }
  while (Console.ReadKey().Key != ConsoleKey.Escape);

  Console.WriteLine("");
  Salve(text);
}

static void Salve(string text)
{
  Console.Clear();

  Console.WriteLine("Digit your path");
  string? path = Console.ReadLine();

  if (path == null) return;

  using (var fs = new StreamWriter(path))
  {
    fs.Write(text);
  }

  Console.WriteLine($"File saved successfuly at {path}");

  Thread.Sleep(1000);

  Menu();
}




