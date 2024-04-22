using RequestTrackerAppModelLibrary;
using System.Collections;
using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.CustomException;

namespace RequestTrackerApp
{
    internal class Program
    {
        void AddDepartment()
        {
            DepartmentBL departmentBL = new DepartmentBL();
            try
            {
                Console.WriteLine("Please enter the department name");
                string name = Console.ReadLine();
                Department department = new Department() { Name = name };
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
                Console.WriteLine("Please enter the department name");
                name = Console.ReadLine();
                department = new Department() { Name = name };
                id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }

        void AddEmployee()
        {
            EmployeeBL employeeBL = new EmployeeBL();
            try
            {
                Console.WriteLine("Please enter the Employee name");
                string name = Console.ReadLine();
                Employee employee = new Employee() { Name = name };
                int id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We ahve created the Employee  and the Id is " + id);
                Console.WriteLine("Please enter the Employee name");
                name = Console.ReadLine();
                employee = new Employee() { Name = name };
                id = employeeBL.AddEmployee(employee);
                Console.WriteLine("Congrats. We ahve created the Employee and the Id is " + id);
            }
            catch (DuplicateEmployeeException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }

        void UpdateEmployeeb()
        {
            EmployeeBL employeeBL = new EmployeeBL();
            try
            {
                Console.WriteLine("Please enter the Employee Old name");
                string Oldname = Console.ReadLine();
                Console.WriteLine("Please enter the Employee New name");
                string NewName = Console.ReadLine();
                Employee emp = employeeBL.ChangeEmployeeName(Oldname, NewName);
                Console.WriteLine("Congrats. We have updated the Employee name and the New name is " + emp.Name);
            }
            catch (EmployeeNotFoundException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        void UnderstaingList()
        {
            ArrayList list = new ArrayList();
            list.Add(100);
            list.Add("Hello");
            list.Add(23.4);
            list.Add(90.3f);
            double total = 0;
            list.Add(new Employee(101, "Ramu", new DateTime(), "Admin"));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                total = Convert.ToDouble(list[i]);
            }
        }
        void UnderstandingGenericList()
        {
            List<int> numbers = new List<int>();
            numbers.Add(100);
            numbers.Add(79);
            numbers.Add(55);
            numbers.Add(79);
            double total = 0;
            //for (int i = 0;i < numbers.Count;i	++)
            //{
            //    Console.WriteLine(numbers[i]);
            //    total += numbers[i];
            //}
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
                total += i;
            }
            Console.WriteLine($"Total is {total}");
        }
        void UnderstandingSet()
        {
            HashSet<string> names = new HashSet<string>()
            {
                "Ramu","Bimu"
            };
            names.Add("Somu");
            names.Add("Komu");
            names.Add("Timu");
            names.Add("Ramu");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
        void UnderstandingDictionary()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(101, "Ramu");
            employees.Add(102, "Komu");
            employees.Add(103, "Bimu");
            employees.Add(104, "Ramu");
            foreach (var key in employees.Keys)
            {
                Console.WriteLine(key + " " + employees[key]);
            }
            if (employees.ContainsKey(101))
                Console.WriteLine("employee 101 present and name is " + employees[101]);
            if (employees.ContainsValue("Somu"))
                Console.WriteLine("there is an emploeye with name Somu in teh collection");
        }
        int Divide(int num1, int num2)
        {
            try
            {
                int result = num1 / num2;
                return result;
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine("You are trying to divide by zero. Its not worth");
            }
            finally
            {
                Console.WriteLine("Release the divide method resource");
            }
            Console.WriteLine("Your division did not go well");
            return 0;

        }
        static void Main(string[] args)
        {
            //new Program().UnderstandingDictionary();

            //int num1, num2, result;
            //try
            //{
            //    num1 = Convert.ToInt32(Console.ReadLine());
            //    num2 = Convert.ToInt32(Console.ReadLine());
            //    result = new Program().Divide(num1, num2);
            //    Console.WriteLine(result);
            //}
            //catch (FormatException fe)
            //{
            //    Console.WriteLine(fe.Message);
            //    Console.WriteLine("The given data could not be converted to number.");
            //}
            //Console.WriteLine("Bye bye");

            //new Program().AddDepartment();
            Program program = new Program();
            program.AddEmployee();
            program.UpdateEmployeeb();
        }
    }
}
      