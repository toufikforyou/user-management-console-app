using IAdminManagmentNamespace;

namespace AdminManagementNamespace
{
    public class AdminManagement : IAdminManager
    {
        public bool Login()
        {
            Console.WriteLine("Enter your username:");
            var username = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();

            return username == "toufikforyou" && password == "#password";;

        }
    }
}