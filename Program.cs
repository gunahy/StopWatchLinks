using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchLinks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://lms-cdn.skillfactory.ru/assets/courseware/v1/dc9cf029ae4d0ae3ab9e490ef767588f/asset-v1:SkillFactory+CDEV+2021+type@asset+block/Text1.txt";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<string> lines = new List<string>();
            using (HttpClient client = new HttpClient()) {
                string content = await client.GetStringAsync(url);
                foreach (var line in content.Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        lines.Add(line);
                }
            }

            sw.Stop();
            Console.WriteLine($"Время вставки в конец для List<T>.Add: {sw.ElapsedMilliseconds} мс");
            sw.Restart();

            LinkedList<string> linkedList = new LinkedList<string>();
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(url);
                foreach (var line in content.Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        linkedList.AddLast(line);
                }
            }
            sw.Stop();
            Console.WriteLine($"Время вставки в конец для LinkedList<T>.AddLast: {sw.ElapsedMilliseconds} мс");
            Console.ReadKey();
        }
    }
}
