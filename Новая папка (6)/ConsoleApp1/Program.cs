using System.Text.RegularExpressions;

string rez = @"Result.txt";
string path = @"Input.txt";



// асинхронное чтение
using (StreamReader reader = new StreamReader(path))
{
    string text = await reader.ReadToEndAsync();
    Console.WriteLine(text);

    string[] words = Regex.Split(text, @"\s+");
    int wor = words.Select(x => x.Length).OrderBy(x => x).First();

    string b= "Слово- " + string.Join("\r\n", words.Where(x => x.Length == wor).GroupBy(x => x).Select(x => string.Concat(x.Key, "; кол-во раз попадается в тексте- ", x.Count())));
    Console.WriteLine(b);


using (StreamWriter writer = new StreamWriter(rez, false))
    {
        await writer.WriteLineAsync(text);
        await writer.WriteLineAsync(b);

    }
}
