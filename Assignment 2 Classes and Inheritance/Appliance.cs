using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using System.Security.AccessControl;
using System.Security.Policy;

namespace Assignment_2_Classes_and_Inheritance.Res
{

    public class Appliance
    {
        private string itemNum;
        private string brand;
        private int quantity;
        private long wattage;
        private string color;
        private double price;
        private static List<Appliance> appList = new List<Appliance>(); //turned private
        private string newQuantity;

        public string ItemNum { get => itemNum; set => itemNum = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public long Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }
        public static List<Appliance> AppList { get => appList; set => appList = value; } //added
        public string NewQuantity { get => newQuantity; set => newQuantity = value; }

        public Appliance()
        {
            formatForFile();
        } 
        public Appliance(string itemNum, string brand, int quantity, long wattage, string color, double price )//base
        {
            this.itemNum = itemNum;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.color = color;
            this.price = price;

        }

        /*              CHECKOUT              */
        public static void AppCheckout()
        {
            Console.WriteLine("Enter the item number of an appliance: ");
            string co = Console.ReadLine();


            foreach (Appliance appliance in AppList )
            {

                if (appliance.ItemNum.Contains(co) && (co.Count() == 9) && (appliance.GetQuantity() > 0)) 
                {
                    
                    int newQuantity = Convert.ToInt32(appliance.GetCheckout());

                    Appliance newAppliance = new Appliance();
                    newAppliance.ItemNum = appliance.ItemNum;
                    newAppliance.Brand = appliance.Brand;
                    newAppliance.Quantity = newQuantity;
                    newAppliance.Wattage = appliance.Wattage;
                    newAppliance.Color = appliance. Color;
                    newAppliance.Price = appliance.Price;
                    newAppliance.GetUpdatedList();


                    AppList.Add(newAppliance);

                    Console.WriteLine("new Appliance\n" + newAppliance.ToString());
                    Console.WriteLine("Appliance \'" + co + "\" has been checked out.\n");
                    break;
                }
                else if (appliance.ItemNum.Contains(co) && (co.Count() == 9) && (appliance.GetQuantity() <= 0))
                {
                    Console.WriteLine("The appliance is not available to be checked out.\n");
                }
                else if (!(appliance.ItemNum.Contains(co) && (co.Count() == 9)) && (appliance.GetQuantity() <= 0))
                {
                    Console.WriteLine("No appliances found with that item number.\n");
                }
            }
        }


        /*         FIND APPLIANCE BRAND       */
        public static void findApplianceBrand()
        {
            Console.WriteLine("Enter brand to search for: ");
            string brandSearch =  Console.ReadLine();

            string BrandName = AppList.Find(a => a.brand == brandSearch).brand;
            Console.WriteLine("Matching Appliances:");
            foreach (Appliance item in AppList)
            {
                if (brandSearch == item.brand)
                {
                    Console.WriteLine(item.ToString() + "\n");

                }
            }
        }

        /*         FIND APPLIANCE TYPE       */


        public static void matchType(string appType)
        {

            switch (appType)
            {
                case "1":
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int nd = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nMatching Refridgerator");

                    ///string s = AppList.Find(a => a.GetDoorNum() == nd);

                    foreach(Appliance item in AppList)
                    {
                        if (item.GetFirstCharId() == '1' )// && (AppList.Contains(nd)))
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }

                    break;
                case "2":
                    Console.WriteLine("\nMatching Vacuums");

                    foreach (Appliance item in AppList)
                    {
                        if (item.GetFirstCharId() == '2')
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("\nMatching Microwaves");

                    foreach (Appliance item in AppList)
                    {
                        if (item.GetFirstCharId() == '3')
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }

                    break;
                case "4":
                    Console.WriteLine("\nMatching Dishwasher");

                    foreach (Appliance item in AppList)
                    {
                        if (item.GetFirstCharId() == '4' | item.GetFirstCharId() == '5')
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    break;

            }
        }
        public static void findByType()
        {
            Console.WriteLine("Appliance Types\n1 – Refrigerators\n2 – Vacuums\n3 – Microwaves\n4 – Dishwashers\nEnter type of appliance:");
            string appType = Console.ReadLine();
            matchType(appType);
        }

        /*          RANDOM APPLIANCES       */
        public static void RandomAppliances()
        {
            Console.WriteLine("\nEnter number of appliances:");
            int x = Convert.ToInt32(Console.ReadLine());
            Random randomNumber = new Random();
            

            for (int i = x; i > 0; i--) 
            {
                char RandomNumber = Convert.ToChar(randomNumber.Next(0, 9));
                Console.WriteLine(AppList[RandomNumber].ToString());
            }
        }




        /*            SAVE AND EXIT           */
        public static void saveToFile()
        {
            List <string> updatedList= new List <string>();
            string filePath = "C:\\OOP2 CRPG211\\Module 2\\Assignment 2 Classes and Inheritance\\Assignment 2 Classes and Inheritance\\Res\\appliances.txt";



            foreach (Appliance item in AppList)
            {

                updatedList.Append(item.GetUpdatedList());
            }
            File.AppendAllLines(filePath, updatedList);
        }


        /*              READS FILE            */
        private static void formatForFile()
        {
            string AppPath = "C:\\OOP2 CRPG211\\Module 2\\Assignment 2 Classes and Inheritance\\Assignment 2 Classes and Inheritance\\Res\\appliances.txt";

            string[] lines = File.ReadAllLines(AppPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                string ItemNum = parts[0];
                char firstDigit = ItemNum[0];

                switch (firstDigit)
                {
                    case '1': //Fridge
                        AppList.Add(new Refridgerator(ItemNum, parts[1], int.Parse(parts[2]), long.Parse(parts[3]), 
                            parts[4], double.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8])));
                        break;
                    case '2': //Vacuum
                        AppList.Add(new Vacuum(ItemNum, parts[1], int.Parse(parts[2]), long.Parse(parts[3]), 
                            parts[4], double.Parse(parts[5]), parts[6], int.Parse(parts[7])));
                        break;
                    case '3': //Microwaves
                        AppList.Add(new Microwave(ItemNum, parts[1], int.Parse(parts[2]), 
                            long.Parse(parts[3]), parts[4], double.Parse(parts[5]), double.Parse(parts[6]), char.Parse(parts[7]))); 
                        break;
                    case '4': //Dishwasher                    
                    case '5':
                        AppList.Add(new Dishwasher(ItemNum, parts[1], int.Parse(parts[2]), long.Parse(parts[3]), 
                            parts[4], double.Parse(parts[5]), parts[6], parts[7]));
                        break;
                    default:
                        Console.WriteLine("Error in file text");
                        break;
                }
            }
        }

        public virtual string GetItemNum()
        {
            return ItemNum; //private //no static
        }

        public virtual char GetFirstCharId()
        {
            char fId = ItemNum[0];
            return fId;
        }
        
        public virtual int GetQuantity()
        {
            return Quantity;
        }
        public string GetCheckout()
        {
            int newQ = GetQuantity() - 1;
            return Convert.ToString(newQ);
        }

        /*      FORMATES TO TXT FILE     */
        public virtual string GetUpdatedList()
        {
            return ItemNum + ";" + Brand + ";" + Quantity + ";" + Wattage + ";" + Color + ";" + Price;
        }

        /*    FORMATES TO DISPLAY FILE   */
        public virtual string ToString()
        {
            return "ItemNumber: " +  itemNum + "\nBrand: " + Brand + "\nQuantity: " + Quantity + "\nWattage: " + Wattage + "\nColor: " + Color + "\nPrice: " + Price;
        }
    }
}