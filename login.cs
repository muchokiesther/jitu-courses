using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace assesment
{
    public class login
    {
        static List<DTO> users = new List<DTO>();
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

            
             //   string users = dataRetrieve.retrievedata(filePath);
            //  Console.WriteLine(users);
            

                // if (AuthenticateUser(name, password, roles, out DTO user))
                // {

                //     if (user.roles == "Admin")
                //     {
                //         Console.WriteLine("Logged in as an admin.");

                //     }
                //     else if (user.roles == "User")
                //     {
                //         Console.WriteLine("Logged in as a user.");

                //     }
                //     else
                //     {
                //         Console.WriteLine("Try again.");
                //     }


                //     Console.WriteLine("Login successful!");
                // }
                // else
                // {
                //     Console.WriteLine("Login failed. Wrong credentials.");
                // }
            }
        }


        static bool AuthenticateUser(string name, string password, out DTO user)
        {
            user = users.FirstOrDefault(u => u.name == name && u.password == password);
            return user != null;
        }


    }
}
