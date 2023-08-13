using System;
using System.Collections.Generic;

namespace assesment
{
    public class Register
    {
        static List<DTO> users = new List<DTO>();
          static string filePath = "user.txt";
        // static  Random uuid = new Random();
        
        public static void StartRegistration()
        {
            Console.WriteLine("Welcome to Registration");
            

            while (true)
            {
                Console.WriteLine("Select one:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                      login.StartLogin(); 
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
          

       

            DTO newUser = new DTO
            {
             
                name = name,
                password = password,
    
            };

            users.Add(newUser);

            Console.WriteLine("User registered successfully!");
             SaveUserDataToFile(newUser);
              login.StartLogin();
        }

            static void SaveUserDataToFile(DTO user)
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"{user.name},{user.password}");
                }
            }
    }
}
