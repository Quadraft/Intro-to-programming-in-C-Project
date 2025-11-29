using System;
using System.IO;

namespace ConsoleApp2
{
    // =================================================================
    // CLASS 1: UnitConverter
    // =================================================================
    class UnitConverter
    {
        // Private field for file path (using _ naming convention)
        private readonly string _filePath = "conversion_history.txt";

        // Constructor: Ensures the history file exists when the object is created
        public UnitConverter()
        {
            if (!File.Exists(_filePath))
            {
                // File.Create returns a FileStream, which must be closed.
                File.Create(_filePath).Close();
            }
        }

        // --- 📏 Convert Length (Meters, Kilometers, Miles, Feet) ---
        public void ConvertLength()
        {
            Console.WriteLine("\n--- Length Conversion (m, km, mi, ft) ---");
            Console.WriteLine("1. Meters (m) to Kilometers (km)");
            Console.WriteLine("2. Kilometers (km) to Meters (m)");
            Console.WriteLine("3. Meters (m) to Miles (mi)");
            Console.WriteLine("4. Miles (mi) to Meters (m)");
            Console.WriteLine("5. Feet (ft) to Meters (m)");
            Console.WriteLine("6. Meters (m) to Feet (ft)");
            Console.Write("Select conversion (1-6): ");
            string type = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter value: ");
            // Handle possible null input in TryParse
            if (double.TryParse(Console.ReadLine() ?? string.Empty, out double value))
            {
                double result;
                string historyEntry;

                if (type == "1") // m -> km
                {
                    result = value / 1000;
                    historyEntry = $"{value} m = {result} km";
                }
                else if (type == "2") // km -> m
                {
                    result = value * 1000;
                    historyEntry = $"{value} km = {result} m";
                }
                else if (type == "3") // m -> mi
                {
                    result = value * 0.000621371;
                    historyEntry = $"{value} m = {result:F4} mi";
                }
                else if (type == "4") // mi -> m
                {
                    result = value * 1609.34;
                    historyEntry = $"{value} mi = {result:F2} m";
                }
                else if (type == "5") // ft -> m
                {
                    result = value * 0.3048;
                    historyEntry = $"{value} ft = {result:F4} m";
                }
                else if (type == "6") // m -> ft
                {
                    result = value * 3.28084;
                    historyEntry = $"{value} m = {result:F4} ft";
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                    return;
                }

                Console.WriteLine($"Result: {historyEntry}");
                SaveToHistory(historyEntry);
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }

        // --- ⚖️ Convert Weight (Kilograms, Pounds, Ounces) ---
        public void ConvertWeight()
        {
            Console.WriteLine("\n--- Weight Conversion (kg, lbs, oz) ---");
            Console.WriteLine("1. Kilograms (kg) to Pounds (lbs)");
            Console.WriteLine("2. Pounds (lbs) to Kilograms (kg)");
            Console.WriteLine("3. Kilograms (kg) to Ounces (oz)");
            Console.WriteLine("4. Ounces (oz) to Kilograms (kg)");
            Console.Write("Select conversion (1-4): ");
            string type = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter value: ");
            if (double.TryParse(Console.ReadLine() ?? string.Empty, out double value))
            {
                double result;
                string historyEntry;

                if (type == "1") // kg -> lbs
                {
                    result = value * 2.20462;
                    historyEntry = $"{value} kg = {result:F2} lbs";
                }
                else if (type == "2") // lbs -> kg
                {
                    result = value / 2.20462;
                    historyEntry = $"{value} lbs = {result:F2} kg";
                }
                else if (type == "3") // kg -> oz
                {
                    result = value * 35.274;
                    historyEntry = $"{value} kg = {result:F2} oz";
                }
                else if (type == "4") // oz -> kg
                {
                    result = value / 35.274;
                    historyEntry = $"{value} oz = {result:F4} kg";
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                    return;
                }

                Console.WriteLine($"Result: {historyEntry}");
                SaveToHistory(historyEntry);
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }

        // --- 🌡️ Convert Temperature (Celsius, Fahrenheit, Kelvin) ---
        public void ConvertTemperature()
        {
            Console.WriteLine("\n--- Temperature Conversion (C, F, K) ---");
            Console.WriteLine("1. Celsius (C) to Fahrenheit (F)");
            Console.WriteLine("2. Fahrenheit (F) to Celsius (C)");
            Console.WriteLine("3. Celsius (C) to Kelvin (K)");
            Console.WriteLine("4. Kelvin (K) to Celsius (C)");
            Console.Write("Select conversion (1-4): ");
            string type = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter value: ");
            if (double.TryParse(Console.ReadLine() ?? string.Empty, out double value))
            {
                double result;
                string historyEntry;

                if (type == "1") // C -> F
                {
                    result = (value * 9 / 5) + 32;
                    historyEntry = $"{value} C = {result:F2} F";
                }
                else if (type == "2") // F -> C
                {
                    result = (value - 32) * 5 / 9;
                    historyEntry = $"{value} F = {result:F2} C";
                }
                else if (type == "3") // C -> K
                {
                    // K = C + 273.15
                    result = value + 273.15;
                    historyEntry = $"{value} C = {result:F2} K";
                }
                else if (type == "4") // K -> C
                {
                    // C = K - 273.15
                    result = value - 273.15;
                    historyEntry = $"{value} K = {result:F2} C";
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                    return;
                }

                Console.WriteLine($"Result: {historyEntry}");
                SaveToHistory(historyEntry);
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }

        // --- File Reading (Creativity/Functionality) ---
        public void ShowHistory()
        {
            Console.WriteLine("\n--- Conversion History ---");
            try
            {
                // Reads all lines from the file into a string array
                string[] lines = File.ReadAllLines(_filePath);

                if (lines.Length == 0)
                {
                    Console.WriteLine("History is empty.");
                }
                else
                {
                    // Topic: Loop over array (lines from file)
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        // --- File Writing (File Handling Concept) ---
        private void SaveToHistory(string entry)
        {
            try
            {
                // Format: DateTime: Calculation + new line
                string finalLog = $"{DateTime.Now}: {entry}" + Environment.NewLine;

                // AppendAllText adds the text without overwriting the file
                File.AppendAllText(_filePath, finalLog);
                Console.WriteLine("-> Saved to history file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not save to file: {ex.Message}");
            }
        }
    }

    // =================================================================
    // CLASS 2: Program (The main entry point)
    // =================================================================
    class Program
    {
        // The standard C# entry point
        static void Main()
        {
            Console.WriteLine("=== Midterm Project: Unit Converter ===");

            // OOP: Create an instance (an object) of the UnitConverter class
            UnitConverter converter = new UnitConverter();

            // Arrays: Used for the menu text (updated for clarity)
            string[] menuOptions =
            {
                "1. Convert Length (m, km, mi, ft)",
                "2. Convert Weight (kg, lbs, oz)",
                "3. Convert Temperature (C, F, K)",
                "4. Show History",
                "5. Exit"
            };
            
            // Loops: The main application loop
            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                foreach (string option in menuOptions)
                {
                    Console.WriteLine(option);
                }

                Console.Write("Your choice: ");
                string choice = Console.ReadLine() ?? string.Empty;

                // Conditional statements: Handle user selection
                if (choice == "1")
                {
                    converter.ConvertLength();
                }
                else if (choice == "2")
                {
                    converter.ConvertWeight();
                }
                else if (choice == "3")
                {
                    converter.ConvertTemperature();
                }
                else if (choice == "4")
                {
                    converter.ShowHistory();
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                    break; // Exit the loop
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}