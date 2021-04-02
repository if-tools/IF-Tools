using IFTools.Data.Types;

namespace IFTools.Data
{
    public class FlightState
    {
        public static string GetFlightState(FlightEntry flightEntry)
        {
            var flightState = "";

            var verticalSpeed = flightEntry.VerticalSpeed;
            var altitude = flightEntry.Altitude;
            var speed = flightEntry.Speed;
            
            if (flightEntry.VerticalSpeed < 98 && verticalSpeed > -98 && altitude > 17000 && speed > 350) {
                flightState = "Cruising";
            } else if (verticalSpeed < 98 && verticalSpeed > -98 && altitude < 16998 && speed < 150) {
                flightState = "On Ground";
            } else if (verticalSpeed > 99) {
                flightState = "Climbing";
            } else if (verticalSpeed < -98) {
                flightState = "Descending";
            } else {
                flightState = "N/A";
            }

            return flightState;
        }
    }
}