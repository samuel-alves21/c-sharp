using System.Globalization;

//get the current date
Console.WriteLine(DateTime.Now);

var date = DateTime.Now;

//date format
Console.WriteLine(string.Format("{0:dd/MM/yyyy hh:mm:ss}", date));

//increasing and decreasing dates
Console.WriteLine(date.AddDays(-1));

//date format by local
Console.WriteLine(date.ToString("d", new CultureInfo("pt-BR")));

//global date
Console.WriteLine(DateTime.UtcNow);

//global date to local time
Console.WriteLine(DateTime.UtcNow.ToLocalTime());

//getting a specific timezone
TimeZoneInfo autraliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");

//converting time to a specific timezone
Console.WriteLine("Australia Timezone: " + TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, autraliaTimeZone));