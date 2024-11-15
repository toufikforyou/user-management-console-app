

using UserManagementNamespace;
using UserModelNamespace;

namespace IUserManagmentNamespace
{
    public interface IUserManager
    {
        void Register();
        bool Login();
        void Delete();
    }
}