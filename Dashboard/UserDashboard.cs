using UserManagementNamespace;

namespace UserDashboardNamespace
{
    class UserDashboard
    {
        private UserManagement userManager = new UserManagement();

        public bool UserLogin()
        {
            return userManager.Login();
        }

        public void Dashboard()
        {
            Console.WriteLine("\nWelcome to User Dashboard :)");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Show my info");
                Console.WriteLine("2. Update my info");
                Console.WriteLine("3. Logout my account");

                Console.Write("\nEnter a number: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        userManager.ShowMyInfo();
                        break;
                    case "2":
                        userManager.UpdateMyUser();
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
}