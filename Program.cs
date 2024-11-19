using IUserManagmentNamespace;
using AdminManagementNamespace;
using UserManagementNamespace;

public class Program
{
    static void Main(string[] args)
    {
        AdminManagement adminManager = new AdminManagement();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\t   WELCOME TO USER MANAGEMENT SYSTEM");
            Console.WriteLine("\t\tCreation by Group 7");
            Console.WriteLine("\t\t   ============");
            Console.WriteLine("\n\t\tLogin As an Admin\n");

            while (adminManager.Login())
            {
                Console.Clear();
                Dashboard();
            }

            Console.Write("\nLogin failed. Press ENTER to again login ");
            string exit = Console.ReadLine();
            if (exit == "exit")
            {
                return;
            }
        }

    }

    static void Dashboard()
    {
        Console.WriteLine("\nWelcome to Admin Dashboard:");
        UserManagement userManager = new UserManagement();
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Login User");
            Console.WriteLine("3. Update User");
            Console.WriteLine("4. Delete User");
            Console.WriteLine("5. List of Users");
            Console.WriteLine("6. Logout as admin");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    userManager.Register();
                    break;
                case "2":
                    if (userManager.Login())
                    {
                        Console.WriteLine("\nLogin successful!");
                    }
                    else
                    {
                        Console.WriteLine("\nLogin failed.");
                    }
                    break;
                case "3":
                    userManager.UpdateUser();
                    break;
                case "4":
                    userManager.Delete();
                    break;
                case "5":
                    userManager.ListUsers();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Admin Logout Successfull.");
                    Console.Write("\n\nPress ENTER to again login: ");
                    Console.ReadLine();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}