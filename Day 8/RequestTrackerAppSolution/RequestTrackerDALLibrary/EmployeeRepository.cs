using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RequestTrackerAppModelLibrary;
namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {

        readonly Dictionary<int, Employee> _employee;
        public EmployeeRepository()
        {
            _employee = new Dictionary<int, Employee>();
        }

        public Employee Add(Employee item)
        {
            if (!_employee.ContainsKey(item.Id))
            {
                _employee.Add(item.Id, item);
                return item;
            }
            return null;
        }

        public Employee Delete(int key)
        {
            if (_employee.ContainsKey(key))
            {
                var employee = _employee[key];
                _employee.Remove(key);
                return employee;
            }
            return null;
        }

        public Employee Get(int key)
        {
            return _employee.ContainsKey(key) ? _employee[key] : null;
        }

        public List<Employee> GetAll()
        {
            return _employee.Values.ToList();
        }

        public Employee Update(Employee item)
        {
            if (_employee.ContainsKey(item.Id))
            {
                _employee[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
