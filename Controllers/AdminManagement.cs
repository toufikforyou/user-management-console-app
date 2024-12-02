using AdminErrorNamespace;
using IAdminManagmentNamespace;
using InputErrorNamespace;
using InputHandlingNamespace;

namespace AdminManagementNamespace
{
    public class AdminManagement : IAdminManager
    {
        public bool Login()
        {
            var username = InputHandling.StringInput("Enter your username: ");

            if (username.Length < 2)
            {
                throw new InputError("Username at must be 2 catecters.");
            }

            var password = InputHandling.StringInput("Enter your password: ");

            if (password.Length < 6)
            {
                throw new InputError("password must be 6 catecters.");
            }

            if (((username == "toufikforyou") || (username == "G7")) && password == "#password")
            {
                return true;
            }

            throw new AdminError("Admin Username and password dosn't match");
        }
    }
}