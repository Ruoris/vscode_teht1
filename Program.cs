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

            if (args[0] == "realtime")
            {
                RealTimeCityBikeDataFetcher querier = new RealTimeCityBikeDataFetcher();
                Task<int> bikeamount = querier.GetBikeCountInStation(args[1]);
                Console.WriteLine("Waiting results");
                int result = await bikeamount;
                Console.WriteLine(result);
            }
            else if (args[0] == "offline")
            {
                OfflineTimeCityBikeDataFetcher offQuerier = new OfflineTimeCityBikeDataFetcher();
                Task<int> bikeamount = offQuerier.GetBikeCountInStation(args[1]);
                Console.WriteLine("Waiting results");
                int result = await bikeamount;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("ERROR!");
            }


            // RealTimeCityBikeDataFetcher querier = new RealTimeCityBikeDataFetcher();

            // Task<int> bikeamount = querier.GetBikeCountInStation(args[0]);
            // Console.WriteLine("Waiting results");
            // int result = await bikeamount;
            // Console.WriteLine(result);
        }

    }
}
