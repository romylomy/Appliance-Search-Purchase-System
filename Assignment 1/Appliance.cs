using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_1
{
    public abstract class Appliance
    {
        //Base properties for each class.
        private long itemNumber;
        private string brand;
        private int quantity;
        private double wattage;
        private string color;
        private double price;

        public Appliance()
        {

        }

        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            this.ItemNumber = itemNumber;
            this.Brand = brand;
            this.Quantity = quantity;
            this.Wattage = wattage;
            this.Color = color;
            this.Price = price;
        }

        public long ItemNumber { get => itemNumber; set => itemNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Wattage { get => wattage; set => wattage = value; }
        public string Color { get => color; set => color = value; }
        public double Price { get => price; set => price = value; }

        //Checks if a appliance is available.
        public static bool IsAvailable(Appliance appliance)
        {
            return appliance.quantity > 0;
        }

        //Checksout an available appliance and will overwrite the text file.
        public static void Checkout(List<Appliance> appliances)
        {
            Console.WriteLine("Enter item number: ");
            int input = int.Parse(Console.ReadLine());
            Appliance applianceNumber = appliances.FirstOrDefault(a => a.ItemNumber == input);
            if (applianceNumber != null && Appliance.IsAvailable(applianceNumber))
            {
                applianceNumber.quantity--;
                Console.WriteLine("Appliance " + input + " has been checked out.");
                string formattedString = formatForFile(appliances);
                File.WriteAllText("C:\\assignment\\Assignment 1\\Assignment 1\\Res\\appliances.txt", formattedString);
            }

            //Program could not find a matching appliance.
            else if(applianceNumber == null)
            {
                Console.WriteLine("No appliances found with that item number.");
            }

            //Quantity <= 0 therefore user can not checkout appliance.
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }

        //Overwrites text file and formats it back to original display.
        public static string formatForFile(List<Appliance> appliances)
        {
            StringBuilder formatString = new StringBuilder();
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    formatString.AppendLine($"{appliance.itemNumber};{appliance.brand};{appliance.quantity};{appliance.wattage};{appliance.color};{appliance.price};{refrigerator.NumberOfDoors};{refrigerator.Height};{refrigerator.Width}");
                }
                else if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;
                    formatString.AppendLine($"{appliance.itemNumber};{appliance.brand};{appliance.quantity};{appliance.wattage};{appliance.color};{appliance.price};{vacuum.Grade};{vacuum.BatteryVoltage}");
                }
                else if (appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;
                    formatString.AppendLine($"{appliance.itemNumber};{appliance.brand};{appliance.quantity};{appliance.wattage};{appliance.color};{appliance.price};{microwave.Capacity};{microwave.RoomType}");}
                else if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    formatString.AppendLine($"{appliance.itemNumber};{appliance.brand};{appliance.quantity};{appliance.wattage};{appliance.color};{appliance.price};{dishwasher.SoundRating};{dishwasher.Feature}");
                }
            }

            return formatString.ToString();
        }
        
        //Pre-formatted string method.
        public override string ToString()
        {
            return "Item Number: " + itemNumber + "\nBrand: " + brand + "\nQuantity: " +  quantity + "\nWattage: " + wattage + "\nColor: " + color + "\nPrice: " + price;
        }
    }
}
