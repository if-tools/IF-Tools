using System;

namespace IFTools.Data
{
    public class ServerGuids
    {
        public static Guid CasualServerId;
        public static Guid TrainingServerId;
        public static Guid ExpertServerId;

        public static Guid GetGuidByName(string shortName)
        {
            return shortName.ToLower() switch
            {
                "casual" => CasualServerId,
                "training" => TrainingServerId,
                "expert" => ExpertServerId,
                _ => CasualServerId
            };
        }

        public static string GetNameByGuid(Guid serverId)
        {
            if (serverId == CasualServerId) return "Casual Server";
            if (serverId == TrainingServerId) return "Training Server";
            if (serverId == ExpertServerId) return "Expert Server";
            
            return "N/A";
        }
    }
}