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
    public partial class ForecastScreen : UserControl
    {
        Image background;

        List<Image> icons = new List<Image>();

        int imageY = 30;

        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            #region labels
            //clearing labels
            outputLabel.Text = "";
            temperatureLabel.Text = "";

            //counter 
            int i = 1;
            
            //writting on labels
            foreach (Day d in Form1.days)
            {
                double low = Convert.ToDouble(d.tempLow);
                double high = Convert.ToDouble(d.tempHigh);

                outputLabel.Text += DateTime.Now.AddDays(i).DayOfWeek.ToString() ;
                outputLabel.Text += "\n" + d.condition + "\n" + "\n";

                temperatureLabel.Text += "H: " + high.ToString("##") + "\u00B0" + "C" + "     L: " + low.ToString("##") + "\u00B0" + "C" + "\n" + "\n" + "\n";
                i++;
            }
            #endregion

            #region setting background images/font colour
            string con = Form1.days[0].conditionIcon;

            //change the background image based on weather conditions
            if (con == "01d" || con == "01n")
            {
                background = Properties.Resources.sunny_2_blr;
                outputLabel.ForeColor = System.Drawing.Color.DimGray;
                temperatureLabel.ForeColor = System.Drawing.Color.DimGray;
            }
            if (con == "02d" || con == "03d" || con == "02n" || con == "03n" || con == "50d" || con == "50n" || con == "04d" || con == "04n")
            {
                background = Properties.Resources.cloudy_blr;
                outputLabel.ForeColor = System.Drawing.Color.White;
                temperatureLabel.ForeColor = System.Drawing.Color.White;
            }
            if (con == "09d" || con == "09n")
            {
                background = Properties.Resources.rainy_blr;
                outputLabel.ForeColor = System.Drawing.Color.White;
                temperatureLabel.ForeColor = System.Drawing.Color.White;
            }
            if (con == "10d" || con == "10n")
            {
                background = Properties.Resources.extraRainy_blr;
                outputLabel.ForeColor = System.Drawing.Color.White;
                temperatureLabel.ForeColor = System.Drawing.Color.White;
            }
            if (con == "11d" || con == "11n")
            {
                background = Properties.Resources.thunder_blr;
                outputLabel.ForeColor = System.Drawing.Color.White;
                temperatureLabel.ForeColor = System.Drawing.Color.White;
            }
            if (con == "13d" || con == "13n")
            {
                background = Properties.Resources.snow_blr;
                outputLabel.ForeColor = System.Drawing.Color.DimGray;
                temperatureLabel.ForeColor = System.Drawing.Color.DimGray;

            }
            #endregion

            #region setting icons
            //for each day in the days list, create an image and set it to the appropriate weather icon for the day's condition.
            foreach (Day d in Form1.days)
            {
                Image image = Properties.Resources._01n;

                if (d.conditionIcon == "01d"|| d.conditionIcon == "01n") { image = Properties.Resources._01n; }
                if (d.conditionIcon == "02d"|| d.conditionIcon == "02n") { image = Properties.Resources._02n; }
                if (d.conditionIcon == "03d"||d.conditionIcon =="03n") { image = Properties.Resources._03n; }
                if (d.conditionIcon == "04d" || d.conditionIcon == "04n") { image = Properties.Resources._04n; }
                if (d.conditionIcon == "09d" || d.conditionIcon == "09n") { image = Properties.Resources._09n; }
                if (d.conditionIcon == "10d" || d.conditionIcon == "10n") { image = Properties.Resources._10n; }
                if (d.conditionIcon == "11d" || d.conditionIcon == "11n") { image = Properties.Resources._11n; }
                if (d.conditionIcon == "13d" || d.conditionIcon == "13n") { image = Properties.Resources._13n; }

                icons.Add(image);
            }

            #endregion

        }

        private void label3_Click(object sender, EventArgs e)
        {
            //changing screens
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void ForecastScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(background, 0, 0);

            foreach (Image i in icons)
            {
                //draw the appropriate weather icon
                e.Graphics.DrawImage(i, 0, imageY, 50, 50);

                //add 60 to the next image's y coordinate
                imageY += 58;
            }

            //reset imageY to 85
            imageY = 30;
        }
    }
}
