using Assignment_2_Classes_and_Inheritance.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_Classes_and_Inheritance
{
    public class Microwave : Appliance
    {
        private double capacity;
        private char roomType;
        public double Capacity { get => capacity; set => capacity = value; }
        public char RoomType { get => roomType; set => roomType = value; }
        public Microwave()
        {

        }

        public Microwave(string itemNum, string brand, int quantity, long wattage, string color,
            double price, double capacity, char roomType) : base(itemNum, brand, quantity, wattage, color, price)
        {
            this.capacity = capacity;
            this.roomType = roomType;
        }

        public string GetRoomType()
        { 
            if (roomType == 'K')
            {
                return "kitchen";
            }
            else
            {
                return "Work site";
            }
            
        }

        public override string ToString()
        {
            return base.ToString() + "\nCapacity: " + capacity + "\nRoom Type: " + GetRoomType() + "\n";
        }
    }
}
