using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AsyncAwaitDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string URL = "https://raw.githubusercontent.com/l3oxer/Doggo/main/README.md";

            //creating a stopwatch to count the execution time
            Stopwatch stopwatch = Stopwatch.StartNew();

            stopwatch.Start();

            var tasks = new List<Task> {ReadFileFromURL(URL),ReadFile()};

            await Task.WhenAll(tasks);

            stopwatch.Stop();
            Console.WriteLine("Time took to execute: " + stopwatch.Elapsed.TotalSeconds);

            //await ReadFile();

            //await ReadFileFromURL(URL);
        }

        //method to read file locally
        static async Task ReadFile()
        {
            Console.WriteLine("Reading text file...");

            //read txt inside the file
            string txt = await File.ReadAllTextAsync("C:\\Users\\iT LOGIX\\Desktop\\random.txt");

            // sleep for 1 sec
            //Thread.Sleep(1000);

            //displays the txt inside the file
            Console.WriteLine("Reading File Completed: \n " + txt);
        }

        //method to read file from url
        static async Task ReadFileFromURL(string URL)
        {
            Console.WriteLine("Reading file from url...");

            using (var httpclient = new HttpClient())
            {
                string result = await httpclient.GetStringAsync(URL);

                Console.WriteLine("file reading from the url completed: \n" + result);
            }
        }
    }
}

 