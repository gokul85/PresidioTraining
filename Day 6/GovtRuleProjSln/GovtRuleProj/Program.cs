using System.Reflection;
using System.Xml.Linq;
using GovtRuleLib;
namespace GovtRuleProj
{
    internal class Program
    {
        static void PrintDetails(Company emp)
        {
            if(emp.Type == "ABC")
            {
                IGovtRules cts = new ABC();
                Console.WriteLine("Employee Id : " + emp.EmpId);
                Console.WriteLine("Employee Name " + emp.Name);
                Console.WriteLine("Employee Department : " + emp.Department);
                Console.WriteLine("Employee Designation : " + emp.Designation);
                Console.WriteLine("Employee Basic Salary : " + emp.BasicSalary);
                Console.WriteLine("Employee PF : " + cts.EmployeePF(emp.BasicSalary));
                Console.WriteLine("Employee Gratuity Amount : " + (cts.GratuityAmount(emp.ServiceCompleted,emp.BasicSalary) == 0 ? "No Gratuity Amount": cts.GratuityAmount(emp.ServiceCompleted, emp.BasicSalary)));
                Console.WriteLine("Employee Leave Details are given below\n" + cts.LeaveDetails());
                Console.WriteLine();
            }
            else
            {
                IGovtRules accenture = new XYZ();
                Console.WriteLine("Employee Id : " + emp.EmpId);
                Console.WriteLine("Employee Name " + emp.Name);
                Console.WriteLine("Employee Department : " + emp.Department);
                Console.WriteLine("Employee Designation : " + emp.Designation);
                Console.WriteLine("Employee Basic Salary : " + emp.BasicSalary);
                Console.WriteLine("Employee PF : " + accenture.EmployeePF(emp.BasicSalary));
                Console.WriteLine("Employee Gratuity Amount : " + accenture.GratuityAmount(emp.ServiceCompleted, emp.BasicSalary));
                Console.WriteLine("Employee Leave Details are given below\n" + accenture.LeaveDetails());
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Company cts1 = new ABC(101, "Ram", "IT", "Software Developer", 400000, Convert.ToDateTime("2020-12-12"));
            Company cts2 = new ABC(102, "Raju", "IT", "DevOps Engineer", 500000, Convert.ToDateTime("2015-12-12"));
            Company accenture1 = new XYZ(101, "Ramu", "Sales and Marketing", "Sales Head", 400000, Convert.ToDateTime("2020-12-12"));
            Company accenture2 = new XYZ(102, "Raj", "IT", "Manager", 700000, Convert.ToDateTime("2012-12-12"));
            PrintDetails(cts1);
            PrintDetails(cts2);
            PrintDetails(accenture1);
            PrintDetails(accenture2);
        }
    }
}
