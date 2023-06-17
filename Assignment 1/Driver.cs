using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.IO.MemoryMappedFiles;

/*
    Jerome Corpuz, Zeus Estrella, Cyan Marzan

    Created 2023/02/09

    This program is a system that allows users to search/purchase appliances.
    It contains 4 appliance types separated into 4 classes, Refrigerators, Vacuums, Microwaves, & Dishwashers.
    Each class/appliance is a child class of the parent class - Appliance, which contains the base properties of each class/application, as well as the methods used.
    The methods include IsAvailable, which checks if an appliance is available for checkout, Checkout, which checks out an available appliance, formatForFile, which formats the updated data back into the text file, and the ToString method.
    The final class, Driver, consists of the appliance list and the main menu.
    The menu will ask the user on what they would like to do and prompts for user input.
    The user can then checkout an appliance, search for an appliance by brand, display appliances based on properties, produce a random number of appliances, or save the purchased appliances and overwrite the text file provided.

*/

namespace Assignment_1
{
    public class Driver
    {

        static void Main(string[] args)
        {
            //Creates a new list of appliances and separates each appliance into specified appliance classes with their respective properties.
            List<Appliance> appliances = new List<Appliance>();
            string filePath = "C:\\assignment\\Assignment 1\\Assignment 1\\Res\\appliances.txt";
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');

                string indextarget = fields[0];
                char itemNumbertarget = indextarget[0];

                switch (itemNumbertarget)
                {
                    case '1':
                        appliances.Add(new Refrigerator(long.Parse(fields[0]), fields[1], int.Parse(fields[2]), double.Parse(fields[3]), fields[4], double.Parse(fields[5]), double.Parse(fields[6]), double.Parse(fields[7]), double.Parse(fields[8])));
                        break;
                    case '2':
                        appliances.Add(new Vacuum(long.Parse(fields[0]), fields[1], int.Parse(fields[2]), double.Parse(fields[3]), fields[4], double.Parse(fields[5]), fields[6], int.Parse(fields[7])));
                        break;
                    case '3':
                        appliances.Add(new Microwave(long.Parse(fields[0]), fields[1], int.Parse(fields[2]), double.Parse(fields[3]), fields[4], double.Parse(fields[5]), double.Parse(fields[6]), fields[7]));
                        break;
                    case '4':
                        appliances.Add(new Dishwasher(long.Parse(fields[0]), fields[1], int.Parse(fields[2]), double.Parse(fields[3]), fields[4], double.Parse(fields[5]), fields[6], fields[7]));
                        break;
                    case '5':
                        appliances.Add(new Dishwasher(long.Parse(fields[0]), fields[1], int.Parse(fields[2]), double.Parse(fields[3]), fields[4], double.Parse(fields[5]), fields[6], fields[7]));
                        break;
                }

            }
            bool continueLoop = true;
            while (continueLoop)
            {
                //Main Menu, loops until user enters 5 (Save & Exit)
                Console.WriteLine("Welcome to Modern Appliances!\r\nHow may we assist you?\r\n1 – Check out appliance\r\n2 – Find appliances by brand\r\n3 – Display appliances by type\r\n4 – Produce random appliance list\r\n5 – Save & exit\r\n");
                int userResponse = int.Parse(Console.ReadLine());
                switch (userResponse)
                {
                    //Checkout an available appliance
                    case 1:
                        Appliance.Checkout(appliances);
                        break;

                    /*Search appliance by brand
                      If no appliance is found, program will display an error.*/
                    case 2:
                        Console.WriteLine("Enter brand to seach for: ");
                        string brandTarget = Console.ReadLine().ToLower();
                        bool matchFound = false;

                        foreach (Appliance ap in appliances)
                        {
                            if (ap.Brand.ToLower() == brandTarget)
                            {
                                if (ap is Refrigerator)
                                {
                                    Console.WriteLine(((Refrigerator)ap).ToString());
                                }
                                else if (ap is Vacuum)
                                {
                                    Console.WriteLine(((Vacuum)ap).ToString());
                                }
                                else if (ap is Microwave)
                                {
                                    Console.WriteLine(((Microwave)ap).ToString());
                                }
                                else if (ap is Dishwasher)
                                {
                                    Console.WriteLine(((Dishwasher)ap).ToString());
                                }
                            }
                        }
                        if (!matchFound)
                        {
                            Console.WriteLine("There are no matching brands.");
                        }
                        break;

                        /*Displays an appliance based on appliance type and search parameters.
                          Will return an error if no appliances are found.*/
                    case 3:
                        Console.WriteLine("Appliance Types\r\n1 – Refrigerators\r\n2 – Vacuums\r\n3 – Microwaves\r\n4 – Dishwashers\r\n");
                        int applianceTypeInput = int.Parse(Console.ReadLine());

                        switch (applianceTypeInput)
                        {
                            case 1:
                                Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                                double doorTypeInput = double.Parse(Console.ReadLine());
                                Console.WriteLine("Matching Refrigerators:");
                                bool refrigeratorMatch = false;

                                foreach (Appliance ap in appliances)
                                {
                                    if (ap is Refrigerator && ((Refrigerator)ap).NumberOfDoors == doorTypeInput)
                                    {
                                        Console.WriteLine(((Refrigerator)ap).ToString());
                                        refrigeratorMatch = true;
                                    }
                                }
                                if (!refrigeratorMatch)
                                {
                                    Console.WriteLine("There are no matching refrigerators");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
                                double batterVoltageTypeInput = double.Parse(Console.ReadLine());
                                Console.WriteLine("Matching Vacuums:");
                                bool vacuumMatch = false;

                                foreach (Appliance ap in appliances)
                                {
                                    if (ap is Vacuum && ((Vacuum)ap).BatteryVoltage == batterVoltageTypeInput)
                                    {
                                        Console.WriteLine(((Vacuum)ap).ToString());
                                        vacuumMatch = true;
                                    }
                                }
                                if (!vacuumMatch)
                                {
                                    Console.WriteLine("There are no matching vacuums.");
                                }
                                break;
                            case 3:
                                Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                                string roomTypeInput = Console.ReadLine();
                                Console.WriteLine("Matching Microwaves:");
                                bool microwaveMatch = false;

                                foreach (Appliance ap in appliances)
                                {
                                    if (ap is Microwave && ((Microwave)ap).RoomType == roomTypeInput)
                                    {
                                        Console.WriteLine(((Microwave)ap).ToString());
                                        microwaveMatch = true;
                                    }
                                }
                                if (!microwaveMatch)
                                {
                                    Console.WriteLine("There are no matching microwaves.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                                string soundRatingTypeInput = Console.ReadLine();
                                Console.WriteLine("Matching Dishwashers:");
                                bool dishwasherMatch = false;

                                foreach (Appliance ap in appliances)
                                {
                                    if (ap is Dishwasher && ((Dishwasher)ap).SoundRating == soundRatingTypeInput)
                                    {
                                        Console.WriteLine(((Dishwasher)ap).ToString());
                                        dishwasherMatch = true;
                                    }
                                }
                                if (!dishwasherMatch)
                                {
                                    Console.WriteLine("There are no matching dishwashers.");
                                }
                                break;
                        }
                            break;

                        //Displays random appliances, the number depending on user input.
                    case 4:
                        Console.WriteLine("Enter number of appliances: ");
                        int numberOfAppliances = int.Parse(Console.ReadLine());
                        Console.WriteLine("Random appliances: ");

                        Random random = new Random();
                        for (int i = 0; i < numberOfAppliances; i++)
                        {
                            int index = random.Next(appliances.Count);
                            Console.WriteLine(appliances[index]);
                        }

                        break;

                        //Will save data depending on if user checks out an item and will overwrite the text file.
                    case 5:
                        string formattedString = Appliance.formatForFile(appliances);
                        continueLoop = false;
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
