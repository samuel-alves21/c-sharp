using System.Globalization;

decimal number = 10.555m;

Console.WriteLine(number.ToString("C", new CultureInfo("pt-BR")));
Console.WriteLine(number.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));