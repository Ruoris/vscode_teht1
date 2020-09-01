
using System;
using System.Threading.Tasks;
using System.Linq;

public class OfflineTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
   
public void Sortbiketext()
{
Console.WriteLine("Sorting...");
}
    public  async Task<int> GetBikeCountInStation(string stationName)
    {
        
        string[] b =System.IO.File.ReadAllLines(@"C:\Users\tonir\Documents\vscode teht1\Bikedata.txt");
        string[] completeListOfNames = new string[b.Length];
        string [] completeListOfamounts= new string[b.Length];
        string inserter;
        string insertinter;
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
            var task = new Task(() => Sortbiketext());
        task.Start();
        await task;
            for (int i = 0; i < b.Length; i++)
            {
                string rivi = b[i];

                inserter = new String(rivi.Where(Char.IsLetter).ToArray());

                completeListOfNames[i] = inserter;
              
                insertinter=new String(rivi.Where(Char.IsDigit).ToArray());
                completeListOfamounts[i]=insertinter;


            }
            
            OfflineStations offline=new OfflineStations(completeListOfNames,completeListOfamounts);



            for (int i = 0; i < offline.name.Length; i++)
            {
                if (offline.name[i] == stationName)
                {
                    //bikeCount = ;
                    Console.WriteLine("there are " + offline.bikesAvailable[i] + " bikes at "+offline.name[i]);
                    return  1;
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

return 1;
    }

}
public class OfflineStations
{
    public OfflineStations(string[] lines, string[] bikes)
    {
        name = lines;
        bikesAvailable = bikes;
    }
    public string[] name { get; set; }
    public string[] bikesAvailable { get; set; }
}

