using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Vacuum : Appliance
    {
        //Vacuum properties + appliance base properties.
        private string grade;
        private int batteryVoltage;

        public Vacuum()
        {

        }

        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, string grade, int batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Grade = grade;
            this.BatteryVoltage = batteryVoltage;
        }

        public string Grade { get => grade; set => grade = value; }
        public int BatteryVoltage { get => batteryVoltage; set => batteryVoltage = value; }

        //Depending on user input, it will display the base properties for all appliances + unique Vacuum properties.
        public override string ToString()
        {
            string voltageType = "";
            if (BatteryVoltage == 18)
            {
                voltageType = "Low";
            }
            else if (BatteryVoltage == 24)
            {
                voltageType = "High";
            }

            return base.ToString() + "\nGrade: " + grade + "\nBattery Voltage: " + voltageType;
        }
    }
}
