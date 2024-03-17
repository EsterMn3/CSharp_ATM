using System;

namespace ATM
{
    class Program
    {
        static double balance = 1000; // Initial account balance
        static int pin = 1234; // Predefined PIN

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM!");

            // Perform user authentication
            if (!AuthenticateUser())
            {
                Console.WriteLine("Authentication failed. Exiting...");
                return;
            }

            // If authentication succeeds, display menu options
            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");

                int choice = GetIntegerInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        CheckBalance();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the ATM!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // User authentication method
        static bool AuthenticateUser()
        {
            Console.Write("Enter your PIN: ");
            int enteredPIN;
            if (int.TryParse(Console.ReadLine(), out enteredPIN))
            {
                if (enteredPIN == pin)
                {
                    return true; // Authentication successful
                }
            }
            return false; // Authentication failed
        }

        static void CheckBalance()
        {
            Console.WriteLine($"Your current balance is: ${balance}");
        }

        static void Deposit()
        {
            double amount = GetDoubleInput("Enter the amount to deposit: ");
            balance += amount;
            Console.WriteLine($"${amount} deposited successfully.");
        }

        static void Withdraw()
        {
            double amount = GetDoubleInput("Enter the amount to withdraw: ");
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"${amount} withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        static int GetIntegerInput(string prompt)
        {
            int input;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input. Please enter an integer.\n");
            }
        }

        static double GetDoubleInput(string prompt)
        {
            double input;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out input) && input > 0)
                {
                    return input;
                }
                Console.WriteLine("Invalid input. Please enter a valid positive number.\n");
            }
        }
    }
}
