using System;
using Newtonsoft.Json;

namespace IFTools.Data.Types
{
    class UserStatsRequest
    {
        [JsonProperty("userIds")]
        public Guid[] UserIds { get; set; }
        
        [JsonProperty("userHashes")]
        public string[] Hashes { get; set; }
        
        [JsonProperty("discourseNames")]
        public string[] IfcNames { get; set; }
    }
}