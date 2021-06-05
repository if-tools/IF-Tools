using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using IFTools.Data.Types;

namespace IFTools.Data
{
    public class AircraftGuidsService
    {
        private static List<GuidAircraftEntry> _aircrafts;

        public static void Init()
        {
            _aircrafts = new List<GuidAircraftEntry>();
            
            using (TextReader reader = File.OpenText(@"wwwroot/csv/aircrafts.csv"))
            {
                CsvReader csv = new CsvReader(reader, CultureInfo.CurrentCulture);
                while (csv.Read())
                {
                    GuidAircraftEntry record = csv.GetRecord<GuidAircraftEntry>();
                    _aircrafts.Add(record);
                }
            } 
        }

        public static string GetAircraftName(Guid aircraftId)
        {
            var match = _aircrafts.Find(aircraft => aircraft.AircraftId == aircraftId);
            
            return match == null ? "N/A" : match.AircraftName;
        }
        
        public static string GetLiveryName(Guid aircraftId, Guid liveryId)
        {
            var match = _aircrafts.Find(aircraft => aircraft.AircraftId == aircraftId && aircraft.LiveryId == liveryId);
            
            return match == null ? "N/A" : match.LiveryName;
        }
    }
}