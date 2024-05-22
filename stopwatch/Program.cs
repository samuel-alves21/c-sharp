Console.Clear();
Menu();

static void Start(int time)
{
  // int count = 0;

  // while (count != time)
  // {
  //   count++;
  //   Console.Clear();
  //   Console.WriteLine(count);
  //   Thread.Sleep(1000);
  // }

  for (int i = 1; i <= time; i++)
  {
    Console.Clear();
    Console.WriteLine(i);
    Thread.Sleep(1000);
  }

  Console.WriteLine("StopWatch finished...");
  Console.WriteLine("");
  Console.WriteLine("");
  Menu();
}

static void Menu()
{
  Console.WriteLine("Choose one of the following options:");
  Console.WriteLine("");
  Console.WriteLine("S - seconds -> 10s");
  Console.WriteLine("M - minutes -> 10m");
  Console.WriteLine("0 - exit");

  string data = Console.ReadLine().ToLower();
  char option = Convert.ToChar(data.Substring(data.Length - 1, 1));
  int time = Convert.ToInt32(data.Substring(0, data.Length - 1));
  int multiplier = 1;
  Console.WriteLine(time);

  if (option == 'm')
  {
    multiplier = 60;
  }

  if (time == 0)
  {
    Environment.Exit(0);
  }

  PreStart(time * multiplier);
}

static void PreStart(int time)
{
  Console.Clear();
  Console.WriteLine("Ready...");
  Thread.Sleep(1000);
  Console.WriteLine("Set...");
  Thread.Sleep(1000);
  Console.WriteLine("Go...");
  Thread.Sleep(2500);

  Start(time);
}