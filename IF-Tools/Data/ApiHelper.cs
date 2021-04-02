using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFTools.Data.Types;

namespace IFTools.Data
{
    public class ApiHelper
    {
        private static Dictionary<Guid, List<FlightEntry>> _cachedFlights = new();
        private static Dictionary<Guid, DateTime> _flightsUpdated = new();
        
        public static async Task<List<FlightEntry>> GetFlightsForServer(Guid serverId)
        {
            if (!_cachedFlights.ContainsKey(serverId))
            {
                _cachedFlights[serverId] = await InfiniteFlightApiService.GetFlightsAsync(serverId);
                _flightsUpdated[serverId] = DateTime.Now;
            }
            
            // Refresh cached flights every 7 seconds
            if ((DateTime.Now - _flightsUpdated[serverId]).TotalMilliseconds >= 7000)
            {
                _cachedFlights[serverId] = await InfiniteFlightApiService.GetFlightsAsync(serverId);
                _flightsUpdated[serverId] = DateTime.Now;
            }
            
            return _cachedFlights[serverId];
        }
        
        public static string BuildUrl(string baseUrl, string endpoint, string parameters)
        {
            return string.Join("",baseUrl, endpoint, "?", parameters);
        }
    }
}