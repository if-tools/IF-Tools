using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IFTools.Data.Types
{
    public class FlightEntry
    {
        [JsonProperty("flightId")]
        public Guid FlightId { get; set; }
        
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        
        [JsonProperty("aircraftId")]
        public Guid AircraftId { get; set; }
        
        [JsonProperty("liveryId")]
        public Guid LiveryId { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("virtualOrganization")]
        public string VirtualOrganization { get; set; }
        
        [JsonProperty("callsign")]
        public string Callsign { get; set; }
        
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        
        [JsonProperty("altitude")]
        public double Altitude { get; set; }
        
        [JsonProperty("speed")]
        public double Speed { get; set; }
        
        [JsonProperty("verticalSpeed")]
        public double VerticalSpeed { get; set; }
        
        [JsonProperty("track")]
        public double Track { get; set; }
        
        [JsonProperty("heading")]
        public float Heading { get; set; }
        
        [JsonProperty("lastReport")]
        public DateTimeOffset LastReport { get; set; }
        
        [JsonIgnore]
        public Guid ServerId { get; set; }
        
        public async Task<FlightPlanEntry> GetFlightPlan(Guid sessionId)
        {
            var flightPlans = await InfiniteFlightApiService.GetFlightPlansAsync(sessionId);
            return flightPlans.FirstOrDefault(p => p.FlightId == FlightId);
        }

        public async Task<UserStats> GetUser()
        {
            Guid[] ids = { UserId };
            return (await  InfiniteFlightApiService.GetUserStatsAsync(ids)).FirstOrDefault();
        }
    }
}
