using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // create list to hold day objects
        public static List<Day> days = new List<Day>();

        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        private void ExtractForecast()
        {
            //Leaving link commented for potential future use
            //XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=Stratford,CA&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");
           
            //extracting data from forecast xml file
            XmlReader reader = XmlReader.Create("WeatherData7Day.xml");

            while (reader.Read())
            {
                //create a day object
                Day day = new Day();

                //fill day object with required data
                reader.ReadToFollowing("time");
                day.date = reader.GetAttribute("day");

                reader.ReadToFollowing("symbol");
                day.condition = reader.GetAttribute("name");
                day.conditionIcon = reader.GetAttribute("var");

                reader.ReadToFollowing("temperature");
                day.tempLow = reader.GetAttribute("min");
                day.tempHigh = reader.GetAttribute("max");

                days.Add(day);

            }

            //removes extra day you get from extracting information from the XML file
            if (days.Count() ==8)
            {
                days.RemoveAt(7);
            }
        }

        private void ExtractCurrent()
        {
            //Leaving link commented for potential future use
            //XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");
            XmlReader reader = XmlReader.Create("WeatherData.xml");

            //find the city and current temperature and add to appropriate item in days list
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("temperature");
            string currentTemp = reader.GetAttribute("value");
            days[0].currentTemp = Convert.ToString(Math.Round(Convert.ToDouble(currentTemp)));
            days[0].tempLow = reader.GetAttribute("min");
            days[0].tempHigh = reader.GetAttribute("max");

            reader.ReadToFollowing("weather");
            days[0].condition = reader.GetAttribute("value");
            days[0].conditionIcon = reader.GetAttribute("icon");

        }


    }
}
