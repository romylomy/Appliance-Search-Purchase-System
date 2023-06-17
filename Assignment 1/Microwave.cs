using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Microwave : Appliance
    {
        //Microwave properties + appliance base properties.
        private double capacity;
        private string roomType;

        public Microwave()
        {

        }

        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, string roomType) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Capacity= capacity;
            this.RoomType= roomType;
        }

        public double Capacity { get => capacity; set => capacity = value; }
        public string RoomType { get => roomType; set => roomType = value; }


        //Depending on user input, it will display the base properties for all appliances + unique Microwave properties.
        public override string ToString()
        {
            string location = "";
            if (RoomType == "K")
            {
                location = "Kitchen";
            }
            else if (RoomType == "W")
            {
                location = "Work site";
            }

            return base.ToString() + "\nCapacity: " + capacity + "\nRoom Type: " + location;
        }
    }
}
