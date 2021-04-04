using Newtonsoft.Json;

namespace IFTools.Data.Types
{
    public class GradeConfiguration
    {
        [JsonProperty("grades")]
        public Grade[] Grades { get; set; }
        
        [JsonProperty("gradeIndex")]
        public int GradeIndex { get; set; }
    }
}
