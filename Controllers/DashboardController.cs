using AdminDashboardNamespace;
using UserDashboardNamespace;

namespace DashboardControllerNamespace
{
    class DashboardController
    {
        private AdminDashboard adminDashboard = new AdminDashboard();
        private UserDashboard userDashboard = new UserDashboard();
        public void AdminLoginPage()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tLogin As an Admin\n");
            while (adminDashboard.AdminLogin())
            {
                Console.Clear();
                adminDashboard.Dashboard();
            }

            Console.Clear();
            Console.Write("\nLogin failed Press ENTER to try again ");
            var tryAgain = Console.ReadLine();
            switch (tryAgain)
            {
                case "back":
                    return;
                default:
                    AdminLoginPage();
                    break;
            }

        }

        public void UserLoginPage()
        {
            Console.Clear();
            Console.WriteLine("\n\t\tLogin As an User\n");
            while (userDashboard.UserLogin())
            {
                Console.Clear();
                userDashboard.Dashboard();
            }

            Console.Clear();
            Console.Write("\nLogin failed Press ENTER to try again ");
            var tryAgain = Console.ReadLine();
            switch (tryAgain)
            {
                case "back":
                    return;
                default:
                    UserLoginPage();
                    break;
            }

        }
    }
}