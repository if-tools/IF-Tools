using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IFTools.Data.Types
{
    public class UserGradeInfo
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        [JsonProperty("virtualOrganization")]
        public string VirtualOrganization { get; set; }
        [JsonProperty("discourseUsername")]
        public string DiscourseUsername { get; set; }
        [JsonProperty("groups")]
        public Guid[] Groups { get; set; }
        [JsonProperty("pilotStats")]
        public GradeInfo PilotStats { get; set; }

        public List<string> GetGroupNames(InfiniteFlightApi apiService)
        {
            return apiService.Groups.Where(g => Groups.Contains(g.Id)).Select(g => g.Name).ToList();
        }
    }
}
