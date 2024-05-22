Console.Clear();

Menu();

Console.ReadKey();

static void Menu()
{
  Console.WriteLine("Welcome! What do you want to do?");
  Console.WriteLine("");

  Console.Write("1 - Sum");
  Console.WriteLine("");
  Console.Write("2 - Sub");
  Console.WriteLine("");
  Console.Write("3 - Div");
  Console.WriteLine("");
  Console.Write("4 - Multi");
  Console.WriteLine("");
  Console.Write("5 - exit");
  Console.WriteLine("");
  Console.WriteLine("");
  Console.WriteLine("");

  Console.Write("Please chose one option...");
  Console.WriteLine("");

  short choice = Convert.ToInt16(Console.ReadLine());

  switch (choice)
  {
    case 1:
      Operate(choice);
      break;
    case 2:
      Operate(choice);
      break;
    case 3:
      Operate(choice);
      break;
    case 4:
      Operate(choice);
      break;
    case 5:
      Environment.Exit(0);
      break;
    default:
      Menu();
      break;
  }
}

static void Operate(short param)
{
  Console.WriteLine("Enter with a number:");
  double v1 = Convert.ToDouble(Console.ReadLine());

  Console.WriteLine("Enter with a second number:");
  double v2 = Convert.ToDouble(Console.ReadLine());

  double result = 0;

  switch (param)
  {
    case 1:
      result = v1 + v2;
      break;
    case 2:
      result = v1 - v2;
      break;
    case 3:
      result = v1 / v2;
      break;
    case 4:
      result = v1 * v2;
      break;
  }

  Console.WriteLine($"The result is: {result}");

  Menu();
}
