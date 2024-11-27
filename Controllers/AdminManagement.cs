using IAdminManagmentNamespace;

namespace AdminManagementNamespace
{
    public class AdminManagement : IAdminManager
    {
        public bool Login()
        {
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            return (username == "toufikforyou" && password == "#password") || (username == "G7" && password == "#G7");
        }
    }
}