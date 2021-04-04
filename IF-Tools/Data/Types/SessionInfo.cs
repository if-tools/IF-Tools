using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IFTools.Data.Types
{
    public class SessionInfo
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("maxUsers")]
        public int MaxUsers { get; set; }
        
        [JsonProperty("userCount")]
        public int UserCount { get; set; }
        
        [JsonProperty("type")]
        public SessionType Type { get; set; }
    }

    public enum SessionType
    {
        Unrestricted,
        Restricted
    }

    public class SessionInfoList : List<SessionInfo>
    {
        public SessionInfo CasualServer => Find(el => el.Name.ToLower().Contains("casual"));
        public SessionInfo TrainingServer => Find(el => el.Name.ToLower().Contains("training"));
        public SessionInfo ExpertServer => Find(el => el.Name.ToLower().Contains("expert"));

    }
}
