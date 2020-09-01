using System;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
            ICityBikeDataFetcher fetcher;
            Console.WriteLine("Give station name and offline/realtime");
            string inputLine = Console.ReadLine();
            string[] inputLines = inputLine.Split(" ");
            switch(inputLines[1]){
                case "offline":
                fetcher = new OfflineCityBikeDataFetcher();
                break;
                case "realtime":
                fetcher = new RealTimeCityBikeDataFetcher();
                break;
                default:
                throw new NotFoundException("Secondary command " +inputLines[1]+" not found");
            }
            
            Task<int> task = fetcher.GetBikeCountInStation(inputLines[0]);
                task.Wait();
                Console.WriteLine("Result is: "+task.Result);

            } catch (AggregateException ae) {
                foreach (Exception Ex in ae.InnerExceptions) {
                    if(Ex is ArgumentException){
                        Console.WriteLine(Ex.Message);
                    }
                    else if (Ex is NotFoundException) {
                        Console.WriteLine(Ex.Message);
                    }
                    else {
                        Console.WriteLine("something went wrong " + Ex.Message);
                    }
                }
            }
            
        }
    }

    class NotFoundException : Exception {
        public NotFoundException(string str) : base(str){
            
        }
    }
}
