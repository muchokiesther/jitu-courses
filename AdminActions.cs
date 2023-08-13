using assesment; 


public class AdminActions

{

    public static void AdminActionsMenu()
    
    {
        while (true)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. View Courses");
            Console.WriteLine("2. Add Course");
            Console.WriteLine("3. Update Course");
            Console.WriteLine("4. Delete Course");
            Console.WriteLine("5. Logout");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewCourses();
                    break;
                case 2:
                    AddCourse();
                    break;

                case 3:
                    UpdateCourse();
                    break;
                case 4:
                    DeleteCourse();
                    break;
                case 5:
                    Console.WriteLine("Logged out.");
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }



   public static void ViewCourses()
{
    string[] lines = File.ReadAllLines("courses.txt");

    foreach (string line in lines)
    {
        string[] parts = line.Split(',');
        if (parts.Length == 3)
        {
            string name = parts[0];
            string description = parts[1];
            decimal price = Convert.ToDecimal(parts[2]);

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine();
        }
    }
}


  public static void AddCourse()
{
    Console.WriteLine("Enter the course name:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the course description:");
    string description = Console.ReadLine();

    Console.WriteLine("Enter the course price:");
    decimal price = Convert.ToDecimal(Console.ReadLine());

    CourseDTO newCourse = new CourseDTO
    {
        Name = name,
        Description = description,
        Price = price
    };

    // Save the course to the file
    SaveCourseToFile(newCourse);

    Console.WriteLine("Course added successfully!");
}

private static void SaveCourseToFile(CourseDTO course)
{
    using (StreamWriter writer = File.AppendText("courses.txt"))
    {
        writer.WriteLine($"{course.Name},{course.Description},{course.Price}");
    }
}


    public static void UpdateCourse()
    {
        // Implement updating a course
    }

    public static void DeleteCourse()
    {
        // Implement deleting a course
    }
}
