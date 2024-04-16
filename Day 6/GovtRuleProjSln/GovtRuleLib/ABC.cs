using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRuleLib
{
    public class ABC : Company, IGovtRules
    {
        public ABC() { }
       
        public ABC(int id, string name, string dept, string desg, double basicSalary, DateTime doj):base(id,name,dept,desg,basicSalary,doj)
        {
            Type = "ABC";
        }

        public double EmployeePF(double basicSalary)
        {
            return (3.67 * basicSalary) / 100 ;
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted < 5)
                return 0;
            else if (serviceCompleted >= 5 && serviceCompleted < 10)
                return basicSalary / 12;
            else if (serviceCompleted >= 10 && serviceCompleted < 20)
                return basicSalary * 2;
            else
                return basicSalary * 3;
        }

        public string LeaveDetails()
        {
            return "1 day of Casual Leave per month\r\n12 days of Sick Leave per year\r\n10 days of Privilege Leave per year";
        }
    }
}
