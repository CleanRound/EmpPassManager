namespace EmployeeManagementApp
{
    class Program
    {
        private static Dictionary<string, string> employeeData = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEmployee Management System");
                Console.WriteLine("1. Add Employee Login and Password");
                Console.WriteLine("2. Delete Employee Login");
                Console.WriteLine("3. Change Employee Login and Password");
                Console.WriteLine("4. Get Password by Employee Login");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        DeleteEmployee();
                        break;
                    case "3":
                        ChangeEmployeeInfo();
                        break;
                    case "4":
                        GetEmployeePassword();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter employee login: ");
            string login = Console.ReadLine();
            if (employeeData.ContainsKey(login))
            {
                Console.WriteLine("Employee login already exists.");
                return;
            }

            Console.Write("Enter employee password: ");
            string password = Console.ReadLine();
            employeeData.Add(login, password);
            Console.WriteLine("Employee added successfully.");
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter employee login to delete: ");
            string login = Console.ReadLine();
            if (employeeData.Remove(login))
            {
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee login not found.");
            }
        }

        static void ChangeEmployeeInfo()
        {
            Console.Write("Enter employee login to change: ");
            string login = Console.ReadLine();
            if (!employeeData.ContainsKey(login))
            {
                Console.WriteLine("Employee login not found.");
                return;
            }

            Console.Write("Enter new login: ");
            string newLogin = Console.ReadLine();
            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            employeeData.Remove(login);
            employeeData[newLogin] = newPassword;

            Console.WriteLine("Employee information changed successfully.");
        }

        static void GetEmployeePassword()
        {
            Console.Write("Enter employee login to get password: ");
            string login = Console.ReadLine();
            if (employeeData.TryGetValue(login, out string password))
            {
                Console.WriteLine($"Password for login '{login}' is: {password}");
            }
            else
            {
                Console.WriteLine("Employee login not found.");
            }
        }
    }
}
