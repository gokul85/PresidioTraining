using RequestTrackerAppModelLibrary;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RequestTrackerBLLibrary.CustomException;
using RequestTrackerDALLibrary;
namespace RequestTrackerBLLibrary

{
    public class EmployeeBL : IEmployeeServices
    {
        readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public int AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Employee cannot be null");

            if (_employeeRepository.Get(employee.Id) != null)
                throw new DuplicateEmployeeException();

            var addedEmployee = _employeeRepository.Add(employee);
            return addedEmployee != null ? addedEmployee.Id : -1;

        }

        public Employee ChangeEmployeeName(string employeeOldName, string employeeNewName)
        {
            if (string.IsNullOrWhiteSpace(employeeOldName))
                throw new ArgumentException("Old employee name cannot be null or empty");

            if (string.IsNullOrWhiteSpace(employeeNewName))
                throw new ArgumentException("New employee name cannot be null or empty");

            var employee = _employeeRepository.GetAll().Find(e => e.Name.Equals(employeeOldName, StringComparison.OrdinalIgnoreCase));
            if (employee == null)
                throw new EmployeeNotFoundException();

            employee.Name = employeeNewName;
            _employeeRepository.Update(employee);
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
                throw new EmployeeNotFoundException();

            return employee;
        }

        public Department GetEmployeeDepartment(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);
            if (employee == null)
                throw new EmployeeNotFoundException();

            return employee.EmployeeDepartment;
        }

        public Employee GetEmplyeeByName(string employeeName)
        {
            if (string.IsNullOrWhiteSpace(employeeName))
                throw new ArgumentException("Employee name cannot be null or empty");

            var employee = _employeeRepository.GetAll().Find(e => e.Name.Equals(employeeName, StringComparison.OrdinalIgnoreCase));
            if (employee == null)
                throw new EmployeeNotFoundException();

            return employee;
        }
    }
}
