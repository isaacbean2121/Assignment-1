using Assignment_2_Classes_and_Inheritance.Res;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_Classes_and_Inheritance
{
    public class Refridgerator : Appliance
    {
        private int numDoors;
        private double height;
        private double width;
        public int NumDoors { get => numDoors; set => numDoors = value; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }
        public Refridgerator() { }


        public Refridgerator(string itemNum, string brand, int quantity, long wattage, string color,
            double price, int numDoors, int height, int width) : base(itemNum, brand, quantity, wattage, color, price)

        {
            this.numDoors = numDoors;
            this.height = height;
            this.width = width;

        } 
        
        public string GetItemNum()
        {
            return ItemNum;
        }

        public char GetFirstCharId()
        {
            return ItemNum[0]; //private //no static
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public override string GetUpdatedList()
        {
            return base.GetUpdatedList() + NumDoors + ";" + Height + ";" + Width;
        }

        public override string ToString() //overide or virt
        {
            return base.ToString() + "\nNumber of Doors: " + NumDoors + "\nHeight: " + Height + "\nWidth: " + Width + "\n";
        }

    }

}
