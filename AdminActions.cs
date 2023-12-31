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
            Console.WriteLine("5. View Analytics");

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
                    ViewAnalytics();
                    break;
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

        List<CourseDTO> courses = ReadCoursesFromFile();

        Console.WriteLine("Enter the name of the course to update:");
        string courseNameToUpdate = Console.ReadLine();


        CourseDTO courseToUpdate = courses.FirstOrDefault(course => course.Name == courseNameToUpdate);

        if (courseToUpdate != null)
        {
            Console.WriteLine("Enter the new course name:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the new course description:");
            string newDescription = Console.ReadLine();

            Console.WriteLine("Enter the new course price:");
            decimal newPrice = Convert.ToDecimal(Console.ReadLine());


            courseToUpdate.Name = newName;
            courseToUpdate.Description = newDescription;
            courseToUpdate.Price = newPrice;


            SaveCoursesToFile(courses);

            Console.WriteLine("Course updated successfully!");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }

    private static List<CourseDTO> ReadCoursesFromFile()
    {
        List<CourseDTO> courses = new List<CourseDTO>();
        string[] lines = File.ReadAllLines("courses.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3)
            {
                string name = parts[0];
                string description = parts[1];
                decimal price = Convert.ToDecimal(parts[2]);

                CourseDTO course = new CourseDTO
                {
                    Name = name,
                    Description = description,
                    Price = price
                };
                courses.Add(course);
            }
        }

        return courses;
    }

    private static void SaveCoursesToFile(List<CourseDTO> courses)
    {
        using (StreamWriter writer = new StreamWriter("courses.txt"))
        {
            foreach (CourseDTO course in courses)
            {
                writer.WriteLine($"{course.Name},{course.Description},{course.Price}");
            }
        }
    }


    public static void DeleteCourse()
    {
        List<CourseDTO> courses = ReadCoursesFromFile();

        Console.WriteLine("Enter the name of the course to delete:");
        string courseNameToDelete = Console.ReadLine();

      
        CourseDTO courseToDelete = courses.FirstOrDefault(course => course.Name == courseNameToDelete);

        if (courseToDelete != null)
        {
            courses.Remove(courseToDelete);


            SaveCoursesToFile(courses);

            Console.WriteLine("Course deleted successfully!");
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }



    public static void ViewAnalytics()
    {
        try
        {
            string[] analyticsData = File.ReadAllLines("analytics.txt");

            if (analyticsData.Length == 0)
            {
                Console.WriteLine("No analytics data available.");
            }
            else
            {
                Console.WriteLine("Analytics Data:");
                foreach (string line in analyticsData)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Analytics file not found.");
        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred.");
        }
    }



}
