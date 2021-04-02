using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IFTools.Data.Types
{
    public class ReportEntry
    {
        [JsonProperty("type")]
        public short Type { get; set; }

        [JsonProperty("creationTime")]
        public DateTimeOffset CreationTime { get; set; }
        
        [JsonProperty("creatorId")]
        public Guid CreatorId { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("flightId")]
        public string FlightId { get; set; }

        public async Task<UserStats> GetCreator()
        {
            Guid[] ids = { CreatorId };
            var res = await InfiniteFlightApiService.GetUserStatsAsync(ids);
            
            return res.FirstOrDefault();
        }
    }
}
