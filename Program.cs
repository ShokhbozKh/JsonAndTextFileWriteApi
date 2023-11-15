using ConsoleApp1.Models;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            //fullPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\files";
            string Url = "https://api.coinbase.com/v2/currencies";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            var result = await client.GetAsync("");
            var Json = await result.Content .ReadAsStringAsync();
            var DeJson = JsonSerializer.Deserialize<Money>(Json);

            //text
            string path = @"C:\\Users\\shohb\\OneDrive\\Ishchi stol\\api\\ConsoleApp1\\Baza\\data.json";
            string path2 = @"C:\\Users\\shohb\\OneDrive\\Ishchi stol\\api\\ConsoleApp1\\Baza\\data.txt";
            await DataText(DeJson, path2);

            // json
            await DataJson(DeJson, path2);
            
        }
        static async Task DataJson(Money data, string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(data.ToString());
            }
        }
        static async Task DataText(Money Dejson, string path2)
        {
            if (!File.Exists(path2))
            {
                File.Create(path2).Close();
            }
            using (StreamWriter streamWriter = new StreamWriter(path2))
            {
                string text = "Yangi malumot..";
                await streamWriter.WriteLineAsync(text);

                foreach(var item in Dejson.data)
                {
                    await streamWriter.WriteLineAsync(item.ToString());    
                }   
            }
        }

    }
}