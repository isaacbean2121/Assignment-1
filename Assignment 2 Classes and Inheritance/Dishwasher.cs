using Assignment_2_Classes_and_Inheritance.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_Classes_and_Inheritance
{
    public class Dishwasher : Appliance 
    {
        //ItemNumber;Brand;Quantity;Wattage;Color;Price;Feature;SoundRating
        private string feature;
        private string SoundRating;

        public string Feature { get => feature; set => feature = value; }
        public string SoundRating1 { get => SoundRating; set => SoundRating = value; }

        public Dishwasher()
        {

        }

        public Dishwasher(string itemNum, string brand, int quantity, long wattage, string color, double price, string feature, string SoundRating) : base(itemNum, brand, quantity, wattage, color, price)
        {
            this.feature = feature;
            this.SoundRating = SoundRating;
        }

        public override string ToString()
        {
            return base.ToString() + "\nfeature" + feature + "\nSoundRating: " + SoundRating + "\n";
        }

    }
}
