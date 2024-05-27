
//throwing errors
static void ThrowError()
{
  throw new Exception("Error!");
}


// treating errors
int[] numberArray = [1, 2, 3, 4, 5];

try
{
  ThrowError();

  for (int i = 0; i <= 5; i++)
  {
    Console.WriteLine(numberArray[i]);
  }

}
catch (IndexOutOfRangeException ex)
{
  Console.WriteLine("Error: " + ex.Message);
}
catch (Exception ex)
{
  Console.WriteLine("Error: " + ex.Message);
}
finally
{
  Console.WriteLine("Program finished");
}

