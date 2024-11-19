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
            Console.Write("Enter a email: ");
            var email = Console.ReadLine();

            Console.Write("Enter a password: ");
            var password = Console.ReadLine();

            var userLogin = users.Find(u => u.Email == email && u.Password == password);
            return userLogin != null;

        }

        public void UpdateUser()
        {
            Console.Clear();
            Console.Write("Enter a email for search user: ");
            var searchByEmail = Console.ReadLine();

            var userToUpdate = users.FirstOrDefault(u => u.Email == searchByEmail);

            if (userToUpdate != null)
            {
                Console.WriteLine($"\nUsers Current Information:\nNAME: {userToUpdate.Name} EMAIL: {userToUpdate.Email} PASSWORD: ****\n\n");

                Console.Write("Enter update name: ");
                var name = Console.ReadLine();

                Console.Write("Enter update email: ");
                var email = Console.ReadLine();

                Console.Write("Enter or current password: ");
                var password = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    name = userToUpdate.Name;
                }

                if (string.IsNullOrEmpty(email))
                {
                    email = userToUpdate.Email;
                }

                if (string.IsNullOrEmpty(password))
                {
                    password = userToUpdate.Password;
                }

                userToUpdate.Name = name;
                userToUpdate.Email = email;
                userToUpdate.Password = password;
            }
            else
            {
                Console.WriteLine("\nUser not found.");
            }

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
            if (users.Count() > 0)
            {
                Console.WriteLine("All registered users:\n");
                int count = 0;
                foreach (var user in users)
                {
                    count++;
                    Console.WriteLine($"{count}. Name: {user.Name}, Email: {user.Email}");
                }
            }
            else
            {
                Console.WriteLine("Users not found!");
            }

        }
    }
}