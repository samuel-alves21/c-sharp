//array initialization
string[] stringArray = ["hello", "world"];

for (int index = 0; index < stringArray.Length; index++)
{
  Console.WriteLine(stringArray[index]);
}

int[] numberArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

foreach (int number in numberArray)
{
  Console.WriteLine(number);
}

