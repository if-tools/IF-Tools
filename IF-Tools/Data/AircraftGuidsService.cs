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
        private static List<GuidAircraftEntry> _aircraft;

        public static void Init()
        {
            _aircraft = new List<GuidAircraftEntry>();
            
            var http = new HttpClient();
            var aircraftString =
                http.GetStringAsync(
                    "https://raw.githubusercontent.com/if-tools/IF-Tools/develop/IF-Tools/aircraft.csv").Result;

            using TextReader reader = new StringReader(aircraftString);
            
            CsvReader csv = new CsvReader(reader, CultureInfo.CurrentCulture);
            while (csv.Read())
            {
                GuidAircraftEntry record = csv.GetRecord<GuidAircraftEntry>();
                _aircraft.Add(record);
            }
        }

        public static string GetAircraftName(Guid aircraftId)
        {
            var match = _aircraft.Find(aircraft => aircraft.AircraftId == aircraftId);
            
            return match == null ? "N/A" : match.AircraftName;
        }
        
        public static string GetLiveryName(Guid aircraftId, Guid liveryId)
        {
            var match = _aircraft.Find(aircraft => aircraft.AircraftId == aircraftId && aircraft.LiveryId == liveryId);
            
            return match == null ? "N/A" : match.LiveryName;
        }
    }
}