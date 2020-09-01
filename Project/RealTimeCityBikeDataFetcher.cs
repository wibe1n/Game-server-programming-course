using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project {
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher {
        public async Task<int> GetBikeCountInStation(string stationName){
            foreach (char ch in stationName){
                if (char.IsDigit(ch)){
                    throw new ArgumentException("Invalid argument. There is a number in the name");
                }
            }
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(new Uri("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental"));
            Blueprint Object = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), typeof(Blueprint)) as Blueprint;
            foreach (BlueprintPack pack in Object.stations){
                if(pack.name.Contains(stationName)){
                    return pack.bikesAvailable;
                }
            }
            throw new NotFoundException(stationName + " not found.");

        }
    }

}