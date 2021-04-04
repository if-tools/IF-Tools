using System;

namespace IFTools.Data.Types
{
    public class GuidAircraftEntry
    {
        public Guid AircraftId { get; set; }
        public string AircraftName { get; set; }
        public Guid LiveryId { get; set; }
        public string LiveryName { get; set; }
    }
}