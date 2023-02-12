using Assignment_2_Classes_and_Inheritance.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace Assignment_2_Classes_and_Inheritance
                            //  Authors: Derek Sluchinski, Moyo IV, Terrill, Isaac Bean     //
{/// <summary>
 /// This Program is used to read text file
 /// sort appliances using the itemNum
 ///  able to checkout appliances
 ///  display appliances by type
 ///  Produce random appliance list
 ///  and save changes to external file (appliances.txt)
 /// </summary> 
    public class Program
    {
        static void Main(string[] args)
        {
            //Appliance a1 = new Appliance();
            new Appliance();

            MainMenu();
            
            
            Console.ReadKey();
        }

        public static void UserChoice(string userInput)
        {
            switch (userInput)
            {
                case "1": //checkout
                    Appliance.AppCheckout();
                    break;
                case "2": //find by Brand
                    Appliance.findApplianceBrand();
                    break;
                case "3": //display by type
                    Appliance.findByType();
                    break;
                case "4": // random
                    Appliance.RandomAppliances();
                    break;
                case "5": //save and exit
                    Appliance.saveToFile();
                    break;
                default:
                    Console.WriteLine("\n" + userInput + " is not a valid option\n");
                    MainMenu();
                    break;
            }
            MainMenu();//
        }

        public static void MainMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!\nHow may we assist you ?\n1 – Check out appliance\n2 – Find appliances by " +
                "brand\n3 – Display appliances by type\n4 – Produce random appliance list\n5 – Save & exit\nEnter option: ");
            string userInput = Console.ReadLine();
            UserChoice(userInput);
        }
    }
}
