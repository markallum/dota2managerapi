using System;
using System.IO;
using System.Threading.Tasks;

namespace Dota2StatisticsParser
{
    public class Grabber
    {
        private string _apiKey;

        public Grabber()
        {
            _apiKey = File.ReadAllText("ValveAPIKey.txt");
        }

        public async Task<string> Grab()
        {
            return "";
        }
    }
}
