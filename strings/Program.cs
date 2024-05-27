// Working with IDs
Guid id = Guid.NewGuid();

id = new Guid("640a6af5-288c-46eb-adaa-34a75ab800ac");
string stringId = id.ToString();

//String interpolation 
Console.WriteLine($"This is the Id: {id}");

//String Comparison 
Console.WriteLine(stringId.Contains("64"));
Console.WriteLine(stringId.CompareTo("64"));
Console.WriteLine(stringId.Equals("64"));

//Strings index
Console.WriteLine(stringId.CompareTo("64"));
Console.WriteLine(stringId[stringId.Length - 1]);

//The Split Method
Console.WriteLine(stringId.Split("-")[0]);
