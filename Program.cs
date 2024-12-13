using DashboardControllerNamespace;

public class Program
{
    static void Main(string[] args)
    {
        DashboardController dashboardController = new DashboardController();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\t   WELCOME TO USER MANAGEMENT SYSTEM");
            Console.WriteLine("\t\tCreation by Group 7");
            Console.WriteLine("\t\t   ============");
            Console.WriteLine("\nChoose an option:");

            Console.WriteLine("1. Login As Admin");
            Console.WriteLine("2. Login As User");
            Console.WriteLine("3. Exit");

            Console.Write("\nEnter a number: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    dashboardController.AdminLoginPage();
                    break;
                case "2":
                    dashboardController.UserLoginPage();
                    break;
                case "3":
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    }
}