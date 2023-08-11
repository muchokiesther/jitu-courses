using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assesment
{
    public static class dataRetrieve
    {
        static string filePath = "user.txt";
        public static  void  retrievedata(string filePath)
        {

      string[] users = File.ReadAllLines(filePath);
      foreach (string user in users)
            {
                // Split each line into name and password
                string[] parts = user.Split(',');

                if (parts.Length == 2)
                {
                    string name = parts[0];
                    string password = parts[1];

                    // Now you can process the name and password as needed
                    Console.WriteLine($"Name: {name}, Password: {password}");
                }
                else
                {
                    Console.WriteLine($"Invalid line format: {user}");
                }
            }

        }


    }
}


















   
