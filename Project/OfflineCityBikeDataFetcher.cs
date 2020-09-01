using System;
using System.Threading.Tasks;

namespace Project{

    public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher {

        public async Task<int> GetBikeCountInStation(string stationName){
            var text = System.IO.File.ReadAllText("bikedata.txt");
            var lines = text.Split("\n");
            foreach(string str in lines){
                string [] lineSplit = str.Split(" : ");
                if (lineSplit[0] == stationName){
                    return int.Parse(lineSplit[1]);
                }
            }
            throw new NotFoundException(stationName + " not found.");
        }        
    }

}