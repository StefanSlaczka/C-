using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Search Patient by ID");
            Console.WriteLine("3. Remove Patient by ID");
            Console.WriteLine("4. List All Patients");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Please select an option (1-5):");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddPatient();
                    break;
                case "2":
                    SearchPatientById();
                    break;
                case "3":
                    RemovePatientById();
                    break;
                case "4":
                    ListAllPatients();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void AddPatient()
    {
        string? id;
        string? name;
        int age;
        string? condition;
        string? verify;

        while (true)
        {
            Console.WriteLine("Enter your ID:");
            id = Console.ReadLine();

            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();

            age = 0;  // Initialize age to zero for each iteration
            while (true)
            {
                Console.WriteLine("Enter your age:");
                string? ageInput = Console.ReadLine();
                if (ageInput != null && int.TryParse(ageInput, out age))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid number.");
                }
            }

            Console.WriteLine("Enter your condition:");
            condition = Console.ReadLine();

            // Display the gathered information
            Console.WriteLine("Is the following information correct? (If it is, enter 'yes'): ID: {0}, Name: {1}, Age: {2}, Condition: {3}", id, name, age, condition);
            verify = Console.ReadLine();
            if (verify?.ToLower() == "yes")
            {
                break;
            }
            else
            {
                Console.WriteLine("Let's try entering the information again.");
            }
        }

        SavePatientToFile(id, name, age, condition);

        Console.WriteLine("Thank you! Your information has been verified:");
        Console.WriteLine("ID: {0}, Name: {1}, Age: {2}, Condition: {3}", id, name, age, condition);
    }

    static void SavePatientToFile(string? id, string? name, int age, string? condition)
    {
        try
        {
            string filePath = "patients.txt";

            string patientData = $"ID: {id}, Name: {name}, Age: {age}, Condition: {condition}\n";

            File.AppendAllText(filePath, patientData);

            Console.WriteLine("Data saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
        }
    }

    static void SearchPatientById()
    {
        Console.WriteLine("Enter the ID of the patient to search:");
        string? searchId = Console.ReadLine();

        try
        {
            string filePath = "patients.txt";
            string[] lines = File.ReadAllLines(filePath);
            bool found = false;

            foreach (string line in lines)
            {
                if (line.Contains($"ID: {searchId},"))
                {
                    Console.WriteLine("Patient found:");
                    Console.WriteLine(line);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("No patient found with the ID: " + searchId);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }

    static void RemovePatientById(){
        Console.WriteLine("Enter the ID of the patient to search:");
        string? removeId = Console.ReadLine();

        try
        {
            string filePath = "patients.txt";
            List<string> lines = new List<string>(File.ReadAllLines(filePath));
            bool found = false;
            for (int i =0; i< lines.Count; i++ )
            {
                if (lines[i].Contains($"ID: {removeId},")){
                    lines.RemoveAt(i);
                    found = true;
                    break;
                }
            }
            if (found)
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Patient removed Successfully.");
            }
            else
            {
                Console.WriteLine("No patient found with the ID: " + removeId);
            }
        }
        catch (Exception ex)
        {
                Console.WriteLine("An error occurred while removing a patient: " + ex.Message);
        }
    }
    static void ListAllPatients()
    {
        try
        {
            string filePath = "patients.txt";
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }

            Console.WriteLine("Listing all patients:");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }

}
