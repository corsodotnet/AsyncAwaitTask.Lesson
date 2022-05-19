using System;
using System.Net;
using System.Threading.Tasks;

namespace AsyncAwaitTask.Lesson
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DoRequest();

            //int result = await OperazioneLunga();
            //OperazioneBreve();

            //Console.WriteLine($"Result is: {result}");
            Console.ReadLine();
        }
        static async Task<int> OperazioneLunga()
        {
            Console.WriteLine("Operazione Lunga - STARTED");

            await Task.Delay(10000);
            Console.WriteLine("Operazione Lunga - FINISHED");

            return 10; 
           

        }
        static void OperazioneBreve()
        {
            Console.WriteLine("Operazione Breve - STARTED");   
            Console.WriteLine("Operazione Breve - FINISHED");
        }
        public static async Task<string> PingSiteAsync(string url)
        {
            string response = string.Empty;
            var ping = new System.Net.NetworkInformation.Ping();
            var result = await ping.SendPingAsync(url);
            await Task.Delay(5000); // internet è lenta!

            if (result.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                response = $"{url} è online! ";
                return response;
            }
            else
            {
                return String.Empty;
            }

        }
        public static void DoRequest()
        {
            string url = "www.stackoverflow.com";
            var pingTask = PingSiteAsync(url);
            Console.WriteLine($"In attesa di risposta da {url}"); // ->
            Task.WaitAll(pingTask);// ->>>AWAIT
            Console.WriteLine(pingTask.Result);
        }
    }
   
}
