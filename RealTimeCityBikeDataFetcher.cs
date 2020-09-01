using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    int bikeCount;



    public async Task<int> GetBikeCountInStation(string stationName)
    {
        HttpClient bikeamountstringretriever = new HttpClient();

        try
        {
            foreach (char c in stationName)
            {
                if (char.IsDigit(c))
                {
                   
                    System.ArgumentException argEx = new System.ArgumentException("Contains numbers");
                    throw argEx;
                }
            }

            string responseBody = await bikeamountstringretriever.GetStringAsync("https://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            //Console.WriteLine(responseBody);
            BikeRentalStationList bikes = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);
            for (int i = 0; i < bikes.stations.Length; i++)
            {
                if (bikes.stations[i].name == stationName)
                {
                    bikeCount = bikes.stations[i].bikesAvailable;
                    Console.WriteLine("there are " + bikeCount + " bikes at the " + stationName+  " station");
                    return 1;
                }



            }
            NotFoundException not=new NotFoundException("Station is not on the list. Check if you typed correctly");
            throw not;

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            return 1;
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Please provide at least one argument");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid argument:  " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Invalid argument: "+ ex.Message);
        } catch (NotFoundException ex)
        {
        Console.WriteLine("Not found: " +ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("just an exception");
        }
       
        

        return 1;
    }
}