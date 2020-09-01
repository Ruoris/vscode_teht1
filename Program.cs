using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


namespace vscode_teht1
{
    class Program
    {
       


        static async Task Main(string[] args)
        {
            RealTimeCityBikeDataFetcher querier = new RealTimeCityBikeDataFetcher();
            

        
    

            
            Task<int> bikeamount = querier.GetBikeCountInStation(args[0]);
            Console.WriteLine("Waiting results");
            int result = await bikeamount;
            Console.WriteLine(result);
        }

    }
}
