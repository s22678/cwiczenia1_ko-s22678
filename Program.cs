// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

if (args.Length != 1)
{
	throw new ArgumentNullException("");
}
var url = args[0];
if(!Uri.IsWellFormedUriString(url, UriKind.Absolute))
{
    throw new ArgumentException("Niepoprawny url");
}
var regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");
var httpClient = new HttpClient();
var httpResult = await httpClient.GetAsync(url);
if (!httpResult.IsSuccessStatusCode)
{
    throw new Exception("Błąd w czasie pobierania strony");
}
var httpContent = await httpResult.Content.ReadAsStringAsync();
var matches = regex.Matches(httpContent);
if (matches.Count == 0)
{
    throw new Exception("Nie znaleziono adresów email");
}
matches.Select(x => x.Value).Distinct().ToList().ForEach(x => Console.WriteLine(x));
