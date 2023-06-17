using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Refrigerator : Appliance
    {
        //Refrigerator properties + appliance base properties.
        private double numberOfDoors;
        private double height;
        private double width;

        public Refrigerator()
        {

        }

        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, double numberOfDoors, double height, double width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.NumberOfDoors = numberOfDoors;
            this.Height = height;
            this.Width = width;
        }

        public double NumberOfDoors { get => numberOfDoors; set => numberOfDoors = value; }
        public double Height { get => height; set => height = value; }
        public double Width { get => width; set => width = value; }

        //Depending on user input, it will display the base properties for all appliances + unique Refrigerator properties.
        public override string ToString()
        {
            string doorType = "";
            if (NumberOfDoors == 2)
            {
                doorType = "Two Doors";
            }
            else if (NumberOfDoors == 3)
            {
                doorType = "Three Doors";
            }
            else if (NumberOfDoors == 4)
            {
                doorType = "Four Doors";
            }

            return base.ToString() + "\nNumber of Doors: " + doorType + "\nHeight: " + height + "\nWidth: " + width;
        }
    }
}
