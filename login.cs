using System;
using System.IO;

namespace assesment
{
    public class login
    {
        static string filePath = "user.txt";

        public static void StartLogin()
        {
            Console.WriteLine("Welcome Back!!");

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


                        if (selectedCourse.Contains("C# Full Stack Development"))
                        {
                            Console.WriteLine("This course requires a top-up before purchase.");
                            Console.WriteLine("Please enter the amount to top up:");
                            string topUpAmountStr = Console.ReadLine();
                            if (int.TryParse(topUpAmountStr, out int topUpAmount))
                            {
                                //how to top up 
                                Console.WriteLine("Top-up successful! You can now proceed with the purchase.");
                                Console.WriteLine("Do you want to purchase this course? (yes/no)");
                                string purchaseChoice = Console.ReadLine();
                                if (purchaseChoice.ToLower() == "yes")
                                {
                                   
                                    SavePurchaseInfo(name, selectedCourse); 
                                    Console.WriteLine("Purchased a course. Thank you!");
                                }
                                else
                                {
                                    Console.WriteLine("Course not purchased.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid top-up amount.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Do you want to purchase this course? (yes/no)");
                            string purchaseChoice = Console.ReadLine();
                            if (purchaseChoice.ToLower() == "yes")
                            {
                    
                                SavePurchaseInfo(name, selectedCourse); 
                                Console.WriteLine("Purchased a course. Thank you!");
                            }
                            else
                            {
                                Console.WriteLine("Course not purchased.");
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine($"Displaying purchased courses for {name}...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }


        static void SavePurchaseInfo(string username, string courseName)
        {
            using (StreamWriter writer = File.AppendText("analytics.txt"))
            {
                writer.WriteLine($"User: {username}, Purchased Course: {courseName}, Date: {DateTime.Now}");
            }
        }
    }
}