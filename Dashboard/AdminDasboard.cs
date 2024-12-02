using AdminManagementNamespace;
using InputErrorNamespace;
using UserErrorNamespace;
using UserManagementNamespace;

namespace AdminDashboardNamespace
{
    class AdminDashboard
    {
        private UserManagement userManager = new UserManagement();
        private AdminManagement adminManagement = new AdminManagement();
        public bool AdminLogin()
        {
            return adminManagement.Login();
        }

        public void Dashboard()
        {
            Console.WriteLine("\nWelcome to Admin Dashboard:");
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. List of Users");
                Console.WriteLine("5. Logout as admin");

                Console.Write("\nEnter a number: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            userManager.Register();
                        }
                        catch (InputError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (UserError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        break;
                    case "2":
                        try
                        {
                            userManager.UpdateUser();
                        }
                        catch (InputError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (UserError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }

                        break;
                    case "3":
                        try
                        {
                            userManager.Delete();
                        }
                        catch (InputError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (UserError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }

                        break;
                    case "4":
                        try
                        {
                            userManager.ListUsers();
                        }
                        catch (InputError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (UserError err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine($"\n{err.Message}");
                        }

                        break;
                    case "5":
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

}