using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        //image for background
        Image background;

        //for all of the labels on screen
        List<Label> labels = new List<Label>();


        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            #region labels
            double low = Convert.ToDouble(Form1.days[0].tempLow);
            double high = Convert.ToDouble(Form1.days[0].tempHigh);
            double current = Convert.ToDouble(Form1.days[0].currentTemp);

            cityOutput.Text = Form1.days[0].location;
            tempLabel.Text = current.ToString("##") + "\u00B0" + "C";
            minLabel.Text = "L: " + low.ToString("##") + "\u00B0" + "C";
            maxLabel.Text = "H: " + high.ToString("##") + "\u00B0" + "C";
            dateLabel.Text = Form1.days[0].date;
            conditionsLabel.Text = Form1.days[0].condition;

            labels.Add(cityOutput);
            labels.Add(tempLabel);
            labels.Add(minLabel);
            labels.Add(maxLabel);
            labels.Add(dateLabel);
            labels.Add(conditionsLabel);

            #endregion

            #region setting background/font colours
            string con = Form1.days[0].conditionIcon;

            //change the background image based on weather conditions
            if (con == "01d" || con == "01n")
            {
                background = Properties.Resources.sunny_2;

                foreach (Label l in labels)
                {
                    l.ForeColor = System.Drawing.Color.DimGray;
                }
            }
            if (con == "02d" || con == "03d" || con == "02n" || con == "03n"||con == "50d"||con == "50n"|| con == "04d" || con == "04n")
            {
                background = Properties.Resources.cloudy;
                foreach (Label l in labels)
                {
                    l.ForeColor = System.Drawing.Color.White;
                }
            }
           
            if (con == "09d" || con == "09n")
            {
                background = Properties.Resources.rainy;
                foreach (Label l in labels)
                {
                    l.ForeColor = System.Drawing.Color.White;
                }
            }
            if (con == "10d" || con == "10n")
            {
                background = Properties.Resources.extraRainy; 
                foreach (Label l in labels)
                {
                    l.ForeColor = System.Drawing.Color.White;
                }
            }
            if (con == "11d" || con == "11n") { 
                background = Properties.Resources.thunder;
                foreach (Label l in labels)
                {
                    l.ForeColor = System.Drawing.Color.White;
                }
            }
            if (con == "13d" || con == "13n")
            {
                background = Properties.Resources.snow;
                foreach (Label l in labels)
                {
                    l.ForeColor = System.Drawing.Color.DimGray;
                }

            }
            #endregion

        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            //xchanging screens to forecast screen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void CurrentScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(background, 0, 0);
        }
    }
}
