using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IFTools.Data.Types
{
    public class FlightPlanEntry
    {
        [JsonProperty("flightPlanId")]
        public Guid FlightPlanId { get; set; }
        [JsonProperty("flightId")]
        public Guid FlightId { get; set; }
        [JsonProperty("waypoints")]
        public string[] Waypoints { get; set; }
        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        public async Task<FlightEntry> GetFlight(InfiniteFlightApi apiService, Guid sessionId)
        {
            var flights = await apiService.GetFlightsAsync(sessionId);
            
            return flights.FirstOrDefault(f => f.FlightId == FlightId);
        }
    }
}
