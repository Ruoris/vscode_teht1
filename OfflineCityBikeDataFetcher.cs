
using System;
using System.Threading.Tasks;


public class OfflineTimeCityBikeDataFetcher : ICityBikeDataFetcher
{int bikeCount;
    public async Task<int> GetBikeCountInStation(string stationName)
    {
        OfflineStations offline; 
      string [] b  = System.IO.File.ReadAllLines(@"C:\Users\tonir\Documents\Bikedata.txt");

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

           
            for (int i = 0; i <offline.name.Length; i++)
            {
                if (offline.name[i] == stationName)
                {
                    //bikeCount = ;
                    Console.WriteLine("there are " + bikeCount + " bikes at the station");
                    return 1;
                }



            }
            NotFoundException not = new NotFoundException("Station is not on the list. Check if you typed correctly");
            throw not;

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
            Console.WriteLine("Invalid argument: " + ex.Message);
        }
        catch (NotFoundException ex)
        {
            Console.WriteLine("Not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("just an exception");
        }


    }

}
public class OfflineStations
{
    public OfflineStations(string[] lines,int[] bikes)
    {
        name = lines;
        bikesAvailable=bikes;
    }
    public string[] name { get; set; }
    public int[] bikesAvailable{ get; set; }
}

