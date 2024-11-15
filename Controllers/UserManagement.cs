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
            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter a email:");
            var email = Console.ReadLine();

            Console.WriteLine("Enter a password:");
            var password = Console.ReadLine();

            if (users.Exists(u => u.Email == email))
            {
                Console.WriteLine("Email already exists.");
                return;
            }

            users.Add(new User { Name = name ?? "", Email = email ?? "", Password = password ?? "" });

            Console.WriteLine("Registration successful!");
        }

        public bool Login()
        {
            Console.Clear();
            Console.WriteLine("Enter your email:");
            var email = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();

            var userLogin = users.Find(u => u.Email == email && u.Password == password);
            return userLogin != null;

        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Enter your email:");
            var email = Console.ReadLine();

            var userToRemove = users.FirstOrDefault(u => u.Email == email);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("All registered users:");
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
            }
        }
    }
}