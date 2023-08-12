using System;
using System.Collections.Generic;
using System.IO;

namespace assesment
{
    public static class dataRetrieve
    {
        static string filePath = "user.txt";
        
        public static List<DTO> retrievedata(string filePath)
        {
            List<DTO> users = new List<DTO>();

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 2)
                {
                    string name = parts[0];
                    string password = parts[1];

                    users.Add(new DTO { name = name, password = password });
                }
                else
                {
                    Console.WriteLine($"Invalid line format: {line}");
                }
            }

            return users;
        }
    }
}
