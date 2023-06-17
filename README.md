# Appliance-Search-Purchase-System
Authors: Jerome Corpuz, Zeus Estrella, Cyan Marzan
<br>
<br> 
This program is a system that allows users to search for and purchase appliances. It provides functionality for managing four types of appliances: Refrigerators, Vacuums, Microwaves, and Dishwashers. 

<h2> Functionality </h2> 
The system includes the following key features:
<br>
<br>
<ol>
  <li><b> Appliance Classes</b>: The system defines four classes, namely Refrigerators, Vacuums, Microwaves, and Dishwashers, each      representing a specific appliance type. These classes inherit from the parent class "Appliance," which holds the common             properties and methods. </li>
  <br>
  <li><b> Shared Methods</b>: The "Appliance" class provides several methods that are shared by all appliance types. These methods              include:
      <ul> 
        <li> <b> IsAvailable()</b>: Checks if a particular appliance is available for checkout.</li>
        <li><b>Checkout()</b>: Marks an available appliance as checked out.</li>
        <li><b>formatForFile()</b>: Formats the updated appliance data and saves it back into the text file.</li>
        <li><b>ToString()</b>: Returns a string representation of the appliance.</li>
      </ul> 
  </li>
  <br>
  <li> 
    <b> Driver Class:</b> The system includes a class called "Driver" that manages the appliance list and the main menu. It handles      user interaction by presenting a menu with various options:
      <ul> 
        <li>Checkout an appliance.</li>
        <li>Display appliances based on properties.</li>
        <li>Generate a random number of appliances.</li>
        <li>Save the purchased appliances and overwrite the provided text file.</li>
      </ul> 
   </li>
</ol>
<h2> Class Diagram </h2>
<img src="https://github.com/romylomy/Appliance-Search-Purchase-System/assets/115190653/8c67fed9-4607-41e6-8dee-34f23a1f9d6b"> 

<h2> Usage </h2>
To use the system, follow these steps:

<ol> 
  <li>Run the program and access the main menu.</li>
  <li>Choose an option from the menu by entering the corresponding number.</li>
  <li>Follow the prompts and provide any necessary inputs.</li>
  <li>Perform the desired operations, such as checking out an appliance, searching for appliances, or generating random appliances.   </li>
  <li>Save the purchased appliances by selecting the appropriate option in the menu. The system will overwrite the provided text        file with the updated data.
  </li>
</ol> 


