using IUserManagmentNamespace;
using AdminManagementNamespace;
using UserManagementNamespace;

public class Program
{
    static void Main(string[] args)
    {
        AdminManagement adminManager = new AdminManagement();

        while(true)
        {
            Console.Clear();
            Console.WriteLine("\nWelcome to User Managment System");
            Console.WriteLine("Creation by Group 7:");
            Console.WriteLine("\nPlease Login first :)");

            while(adminManager.Login()){
                Console.Clear();
                Program.dashboard();
            }
            
            Console.WriteLine("Login failed. Press enter to again login");
            Console.ReadLine();
        }
        
    }

    static void dashboard(){
        Console.WriteLine("\nWelcome to Dashboard:");
        UserManagement userManager = new UserManagement();
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. User Login");
            Console.WriteLine("3. List Users");
            Console.WriteLine("4. Delete by user");
            Console.WriteLine("5. Logout");

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
                    Console.Clear();
                    Console.WriteLine("Admin Logout Successfull. \n\n Press enter to again login.");
                    Console.ReadLine();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}