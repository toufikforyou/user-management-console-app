using InputErrorNamespace;
using InputHandlingNamespace;
using IUserManagmentNamespace;
using UserErrorNamespace;
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
            var name = InputHandling.StringInput("Enter your name: ");

            if (name.Length < 3) throw new InputError("Name must be 3 carecters.");

            var email = InputHandling.StringInput("Enter a email: ");

            if (!email.Contains("@")) throw new InputError("Email must be valid!");

            var password = InputHandling.StringInput("Enter a password: ");

            if (password.Length < 6) throw new InputError("Password must be 6 carecters");

            if (users.Exists(u => u.Email == email))
            {
                throw new UserError("Email already exists.");
            }

            users.Add(new User { Name = name, Email = email, Password = password });

            Console.WriteLine("\nRegistration successful!");
        }

        public bool Login()
        {
            string email = InputHandling.StringInput("Enter a email: ");

            if (!email.Contains("@"))
            {
                throw new InputError("Email must be valid!");
            }

            string password = InputHandling.StringInput("Enter a password: ");

            if (password.Length < 6)
            {
                throw new InputError("Password must be 6 digit!");
            }

            var userLogin = users.Find(u => u.Email == email && u.Password == password);

            if (userLogin == null) throw new UserError("Your login details not match!");

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

                var name = InputHandling.StringInput("Enter update name: ");

                if (string.IsNullOrEmpty(name))
                {
                    name = userToUpdate.Name;
                }
                else
                {
                    if (name.Length < 3) throw new InputError("Name must be 3 carecters");
                }

                var email = InputHandling.StringInput("Enter update email: ");

                if (string.IsNullOrEmpty(email))
                {
                    email = userToUpdate.Email;
                }
                else
                {
                    if (email.Contains("@")) throw new InputError("Email must be valid");
                }

                var password = InputHandling.StringInput("Enter or current password: ");

                if (string.IsNullOrEmpty(password)) { password = userToUpdate.Password; }
                else
                {
                    if (password.Length < 6) throw new InputError("Password must be 6 carecters");
                }

                userToUpdate.Name = name;
                userToUpdate.Email = email;
                myemail = email;
                userToUpdate.Password = password;

                Console.WriteLine("\nUser successfully updated");
            }
            else
            {
                throw new UserError("User logged out!");
            }
        }

        public void UpdateUser()
        {
            Console.Clear();
            var searchByEmail = InputHandling.StringInput("Enter a email for search user: ");

            if (!searchByEmail.Contains("@")) throw new InputError("Email must be valid!");

            var userToUpdate = users.FirstOrDefault(u => u.Email == searchByEmail);

            if (userToUpdate != null)
            {
                Console.WriteLine($"\nUsers Current Information:\nNAME: {userToUpdate.Name} EMAIL: {userToUpdate.Email} PASSWORD: ****\n\n");

                Console.Write("Enter update name: ");
                var name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    name = userToUpdate.Name;
                }
                else
                {
                    if (name.Length < 3) throw new InputError("Name must be 3 carecters");
                }

                Console.Write("Enter update email: ");
                var email = Console.ReadLine();

                if (string.IsNullOrEmpty(email))
                {
                    email = userToUpdate.Email;
                }
                else
                {
                    if (!email.Contains("@")) throw new InputError("Email must be valid!");
                }

                Console.Write("Enter or current password: ");
                var password = Console.ReadLine();

                if (string.IsNullOrEmpty(password))
                {
                    password = userToUpdate.Password;
                }
                else
                {
                    if (password.Length < 6) throw new InputError("Password must be 6 carecters");
                }

                userToUpdate.Name = name;
                userToUpdate.Email = email;
                userToUpdate.Password = password;

                Console.WriteLine("\nUser successfully updated");
            }
            else
            {
                throw new UserError("User not found");
            }

        }

        public void Delete()
        {
            Console.Clear();
            var email = InputHandling.StringInput("Enter your email: ");

            if (!email.Contains("@")) throw new InputError("Email must be valid");

            var userToRemove = users.FirstOrDefault(u => u.Email == email);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                Console.WriteLine("\nUser deleted successfully.");
            }
            else
            {
                throw new UserError("User not found!");
            }
        }

        public void ShowMyInfo()
        {
            Console.Clear();
            var myInfo = users.FirstOrDefault(u => u.Email == myemail);

            if (myInfo != null)
            {

                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("|\t\tSHOW MY INFORMATION:\t\t\t|");
                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("| SN\t|NAME \t\t\t|Email\t\t\t|");
                Console.WriteLine("|-------|-----------------------|-----------------------|");

                Console.WriteLine($"| {1}\t|{myInfo?.Name}\t\t|{myInfo?.Email}\t|");
                Console.WriteLine("|-------|-----------------------|-----------------------|");
            }
            else
            {
                throw new UserError("User logged out!");
            }

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