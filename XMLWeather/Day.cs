using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp, currentTime, condition, conditionValue, conditionIcon, location, tempHigh, tempLow, 
            windSpeed, windDirection, precipitation, visibility;

        public Day()
        {
            date = currentTemp = currentTime = condition = conditionValue = location = tempHigh = tempLow
                = windSpeed = windDirection = precipitation = visibility = conditionIcon = "";
        }
    }
}
