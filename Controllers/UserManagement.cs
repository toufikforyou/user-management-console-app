using IUserManagmentNamespace;
using UserModelNamespace;

namespace UserManagementNamespace
{
    public class User : UserModel { }
    public class UserManagement : IUserManager
    {
        private static List<UserModel> users = new List<UserModel>();

        public void Register()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Enter a email: ");
            var email = Console.ReadLine();

            Console.Write("Enter a password: ");
            var password = Console.ReadLine();

            if (users.Exists(u => u.Email == email))
            {
                Console.WriteLine("\nEmail already exists.");
                return;
            }

            users.Add(new User { Name = name ?? "", Email = email ?? "", Password = password ?? "" });

            Console.WriteLine("\nRegistration successful!");
        }

        public bool Login()
        {
            Console.Clear();
            Console.Write("Enter your email: ");
            var email = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            var userLogin = users.Find(u => u.Email == email && u.Password == password);
            return userLogin != null;

        }

        public void Delete()
        {
            Console.Clear();
            Console.Write("Enter your email:");
            var email = Console.ReadLine();

            var userToRemove = users.FirstOrDefault(u => u.Email == email);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                Console.WriteLine("\nUser deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nUser not found.");
            }
        }

        public void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("All registered users:\n");
            int count = 0;
            foreach (var user in users)
            {
                count++;
                Console.WriteLine($"{count}. Name: {user.Name}, Email: {user.Email}");
            }
        }
    }
}