using Assignment_2_Classes_and_Inheritance.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_Classes_and_Inheritance
{
    public class Vacuum : Appliance
    {
        private string grade;
        private int batteryVoltage;
        public string Grade { get => grade; set => grade = value; }
        public int BatteryVoltage { get => batteryVoltage; set => batteryVoltage = value; }

        public Vacuum()
        {

        }

        public Vacuum(string itemNum, string brand, int quantity, long wattage, string color,
            double price, string grade, int batteryVoltage) : base(itemNum, brand, quantity, wattage, color, price)
        {
            this.Grade = grade;
            this.BatteryVoltage = batteryVoltage;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public override string GetUpdatedList()
        {
            return base.GetUpdatedList() + Grade + ";" + BatteryVoltage;
        }

        public override string ToString()
        {
            return base.ToString() + "\nGrade:" + grade + "\nBatteryVoltage: " + BatteryVoltage + "\n";
        }
    }
}
