using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Exit");
            Console.WriteLine("Please select an option (1-2):");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddPatient();
                    break;
                case "2":
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

    static void SavePatientToFile(string? id, string? name, int age, string? condition){
        try{
            string filePath = "patients.txt";

            string patientData = $"ID: {id}, Name: {name}, Age: {age}, Condition: {condition}\n";

            File.AppendAllText(filePath, patientData);

            Console.WriteLine("Data saved to file successfully.");
        }
        catch (Exception ex){
            Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
        }
    }
}
