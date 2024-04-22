using RequestTrackerAppModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
namespace RequestTrackerBLLibrary
{
    public interface IEmployeeServices
    {
        int AddEmployee(Employee employee);
        Employee ChangeEmployeeName(string employeeOldName, string employeeNewName);
        Employee GetEmployeeById(int id);
        Employee GetEmplyeeByName(string employeeName);
        Department GetEmployeeDepartment(int employeeId);

    }
}
