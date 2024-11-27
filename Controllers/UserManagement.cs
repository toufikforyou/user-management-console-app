using IUserManagmentNamespace;
using UserModelNamespace;

namespace UserManagementNamespace
{
    public class User : UserModel { }
    public class UserManagement : IUserManager
    {
        private static List<UserModel> users = new List<UserModel>();
        public static string myemail = "";

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
            Console.Write("Enter a email: ");
            var email = Console.ReadLine();

            Console.Write("Enter a password: ");
            var password = Console.ReadLine();

            var userLogin = users.Find(u => u.Email == email && u.Password == password);

            if (userLogin == null) return false;

            myemail = email ?? "";
            return true;
        }

        public void UpdateMyUser()
        {
            Console.Clear();
            var userToUpdate = users.FirstOrDefault(u => u.Email == myemail);

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
                myemail = email;
                userToUpdate.Password = password;

                Console.WriteLine("\nUser successfully updated");
            }
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

                Console.WriteLine("\nUser successfully updated");
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

        public void ShowMyInfo()
        {
            Console.Clear();
            var myInfo = users.FirstOrDefault(u => u.Email == myemail);

            Console.WriteLine("|-------------------------------------------------------|");
            Console.WriteLine("|\t\tSHOW MY INFORMATION:\t\t\t|");
            Console.WriteLine("|-------------------------------------------------------|");
            Console.WriteLine("| SN\t|NAME \t\t\t|Email\t\t\t|");
            Console.WriteLine("|-------|-----------------------|-----------------------|");

            Console.WriteLine($"| {1}\t|{myInfo?.Name}\t\t|{myInfo?.Email}\t|");
            Console.WriteLine("|-------|-----------------------|-----------------------|");

        }
        public void ListUsers()
        {
            Console.Clear();
            if (users.Count() > 0)
            {
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("|\t\tALL REGISTERED USERS LIST:\t\t|");
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("| SN\t|NAME \t\t\t|Email\t\t\t|");
                Console.WriteLine("|-------|-----------------------|-----------------------|");
                int count = 0;
                foreach (var user in users)
                {
                    count++;
                    Console.WriteLine($"| {count}\t|{user.Name}\t\t|{user.Email}\t|");
                    Console.WriteLine("|-------|-----------------------|-----------------------|");
                }
            }
            else
            {
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("\t\t\tUsers not found!");
                Console.WriteLine("|-------------------------------------------------------|");
            }

        }
    }
}