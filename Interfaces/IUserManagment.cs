namespace IUserManagmentNamespace
{
    public interface IUserManager
    {
        void Register();
        bool Login();
        void UpdateUser();
        void Delete();
    }
}