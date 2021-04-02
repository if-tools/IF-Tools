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
    }
}