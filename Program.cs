using IUserManagmentNamespace;
using UserManagementNamespace;

public class Program
{
    static void Main(string[] args)
    {
        UserManagement userManager = new UserManagement();

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. List Users");
            Console.WriteLine("4. Delete by user");
            Console.WriteLine("5. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    userManager.Register();
                    break;
                case "2":
                    if (userManager.Login())
                    {
                        Console.WriteLine("Login successful!");
                    }
                    else
                    {
                        Console.WriteLine("Login failed.");
                    }
                    break;
                case "3":
                    userManager.ListUsers();
                    break;
                case "4":
                    userManager.Delete();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}