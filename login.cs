using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                        Console.WriteLine($"Hi, Admin! lets continue");
                         AdminActions.AdminActionsMenu();
                             break;
                    }
                    else
                    {
                        Console.WriteLine($"Hi, {name}!");
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
    }
}
