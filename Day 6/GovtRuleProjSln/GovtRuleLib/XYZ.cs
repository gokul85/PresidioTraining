using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRuleLib
{
    public class XYZ : Company, IGovtRules
    {
        public XYZ() { }
       
        public XYZ(int id, string name, string dept, string desg, double basicSalary, DateTime doj):base(id,name,dept,desg,basicSalary,doj)
        {
            Type = "XYZ";
        }

        public double EmployeePF(double basicSalary)
        {
            return 0 * basicSalary;
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        public string LeaveDetails()
        {
            return "2 day of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Previlage Leave per year";
        }
    }
}
