// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");
// zle
// dodac throw
try {
    var url = args[0];
}
catch (ArgumentNullException exception)
{
    Console.WriteLine("");
}

var regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");
var httpClient = new HttpClient();
var httpResult = await httpClient.GetAsync(url);
var httpContent = await httpResult.Content.ReadAsStringAsync();
var matches = regex.Matches(httpContent);
matches.Select(x => x.Value).Distinct().ToList().ForEach(x => Console.WriteLine(x));
