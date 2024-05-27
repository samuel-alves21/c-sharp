namespace EditorHtml
{
  public static class Menu
  {

    public static void Show()
    {
      Console.Clear();
      Console.BackgroundColor = ConsoleColor.Black;
      DrawScreen(10, 50);
      WriteOptions();
      short option = Convert.ToInt16(Console.ReadLine());
      handleOption(option);
    }

    public static void DrawScreen(int row, int col)
    {
      DrawHorizontal(col);
      DrawVertical(row, col);
      DrawHorizontal(col);

      static void DrawHorizontal(int col)
      {
        Console.Write("+");

        for (int i = 0; i <= col; i++)
        {
          Console.Write("-");
        }

        Console.Write("+");
        Console.Write("\n");
      }

      static void DrawVertical(int row, int col)
      {
        for (int i = 0; i <= row; i++)
        {
          Console.Write("|");

          for (int lines = 0; lines <= col; lines++)
          {
            Console.Write(" ");
          }

          Console.Write("|");
          Console.Write("\n");
        }
      }
    }

    public static void WriteOptions()
    {
      Console.SetCursorPosition(3, 1);
      Console.WriteLine("HTML Editor");
      Console.SetCursorPosition(3, 3);
      Console.WriteLine("Chose one of the following options:");
      Console.SetCursorPosition(3, 5);
      Console.WriteLine("1 - Edit file");
      Console.SetCursorPosition(3, 6);
      Console.WriteLine("2 - Open file");
      Console.SetCursorPosition(3, 8);
      Console.WriteLine("0 - Exit");
      Console.SetCursorPosition(3, 10);
      Console.Write("type hat do you want to do: ");
    }

    public static void handleOption(short option)
    {
      switch (option)
      {
        case 1:
          {
            Editor.Show();
            break;
          }
        case 2:
          {
            Console.WriteLine("Open");
            break;
          }
        case 0:
          {
            Console.Clear();
            Environment.Exit(0);
            break;
          }
        default:
          {
            Show();
            break;
          }
      }
    }
  }
}