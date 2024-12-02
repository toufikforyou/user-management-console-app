using AdminDashboardNamespace;
using AdminErrorNamespace;
using InputErrorNamespace;
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

            try
            {
                while (adminDashboard.AdminLogin())
                {
                    Console.Clear();
                    adminDashboard.Dashboard();
                }
            }
            catch (InputError err)
            {
                Console.Clear();
                Console.Write($"\n{err.Message}");
            }
            catch (AdminError err)
            {
                Console.Clear();
                Console.Write($"\n{err.Message}");
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.Write($"\n{err.Message}");
            }

            Console.Write("\n\nPress ENTER to try again ");
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
            try
            {
                while (userDashboard.UserLogin())
                {
                    Console.Clear();
                    userDashboard.Dashboard();
                }
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.Write($"\n{err.Message}");
            }

            Console.Write("\n\nPress ENTER to try again ");
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