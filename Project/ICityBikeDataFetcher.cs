using System.Threading.Tasks;

namespace Project {

    public interface ICityBikeDataFetcher
    {
        Task<int> GetBikeCountInStation(string stationName);
    }

}