using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Dishwasher : Appliance
    {
        //Dishwasher properties + appliance base properties.
        private string feature;
        private string soundRating;

        public Dishwasher()
        {

        }

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Feature = feature;
            this.SoundRating = soundRating;
        }

        public string Feature { get => feature; set => feature = value; }
        public string SoundRating { get => soundRating; set => soundRating = value; }

        //Depending on user input, it will display the base properties for all appliances + unique Dishwasher properties.
        public override string ToString()
        {
            string soundType = "";

            if (SoundRating == "Qt")
            {
                soundType = "Quietest";
            }
            else if (SoundRating == "Qr")
            {
                soundType = "Quiter";
            }
            if (SoundRating == "Qu")
            {
                soundType = "Quite";
            }
            else if (SoundRating == "M")
            {
                soundType = "Moderate";
            }

            return base.ToString() + "\nFeature: " + feature + "\nSound Rating: " + soundType;
        }
    }
}
