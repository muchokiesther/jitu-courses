using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace assesment
{
    public class login
    {
        static string filePath = "user.txt";

        public static void StartLogin()
        {
            Console.WriteLine("Welcome Back");

            while (true)
            {
                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string password = Console.ReadLine();

                if (IsRegistered(name, password))
                {
                    if (name.ToLower() == "admin")
                    {
                        Console.WriteLine($"Hi, Admin! Let's continue");
                        AdminActions.AdminActionsMenu();
                    }
                    else
                    {
                        Console.WriteLine($"Hi, {name}!");
                        RegularUserActions(name);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("You haven't registered yet. Please register first.");
                }
            }
        }

        static bool IsRegistered(string name, string password)
        {
            List<DTO> users = dataRetrieve.retrievedata(filePath);
            return users.Any(u => u.name == name && u.password == password);
        }

        static void RegularUserActions(string name)
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. View Courses");
                Console.WriteLine("2. View Purchased Courses");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Displaying available courses...");
                        AdminActions.ViewCourses();
                        Console.WriteLine("Select a course to purchase:");
                        string selectedCourse = Console.ReadLine();
                        decimal coursePrice = 50000.0m; // Simulated course price

                        Console.WriteLine($"Course: {selectedCourse}");
                        Console.WriteLine($"Course Price: {coursePrice}");
                        Console.WriteLine("Do you want to purchase this course? (yes/no)");
                        string purchaseChoice = Console.ReadLine();

                        if (purchaseChoice.ToLower() == "yes")
                        {
                            decimal userBalance = GetUserBalance(name);

                            if (userBalance >= coursePrice)
                            {
                                SavePurchaseInfo(name, selectedCourse);
                                UpdateUserBalance(name, -coursePrice);
                                Console.WriteLine("Purchased a course. Thank you!");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds. Do you want to top up? (yes/no)");
                                string topUpChoice = Console.ReadLine();
                                if (topUpChoice.ToLower() == "yes")
                                {
                                    // Implement logic to simulate topping up
                                    Console.WriteLine("Topped up successfully.");
                                    UpdateUserBalance(name, 50000.0m); // Simulated top-up
                                }
                                else
                                {
                                    Console.WriteLine("Course not purchased.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Course not purchased.");
                        }
                        break;

                    case "2":
                        Console.WriteLine($"Displaying purchased courses for {name}...");
                        DisplayPurchasedCourses(name);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

        static void DisplayPurchasedCourses(string username)
        {
            string[] allPurchases = File.ReadAllLines("analytics.txt");
            bool foundPurchases = false;

            foreach (string purchase in allPurchases)
            {
                if (purchase.Contains($"User: {username}, Purchased Course:"))
                {
                    string purchasedCourse = GetPurchasedCourseName(purchase);
                    Console.WriteLine($"Purchased Course: {purchasedCourse}");
                    foundPurchases = true;
                }
            }

            if (!foundPurchases)
            {
                Console.WriteLine("You haven't purchased any courses yet.");
            }
        }

        static string GetPurchasedCourseName(string purchase)
        {
            int startIndex = purchase.IndexOf("Purchased Course:") + "Purchased Course:".Length;
            int endIndex = purchase.IndexOf(",", startIndex);

            if (startIndex >= 0 && endIndex >= 0)
            {
                return purchase.Substring(startIndex, endIndex - startIndex).Trim();
            }

            return "";
        }

        static void SavePurchaseInfo(string username, string courseName)
        {
            using (StreamWriter writer = File.AppendText("analytics.txt"))
            {
                writer.WriteLine($"User: {username}, Purchased Course: {courseName}, Date: {DateTime.Now}");
            }
        }


// FIGURE OUT HOW TO IMPLEMNET SUCH INSTANCES!
        static decimal GetUserBalance(string username)
        {
          
            return 200.0m; 
        }

        static void UpdateUserBalance(string username, decimal newBalance)
        {
           
        }
    }
}
