using RequestTrackerDALib;
using RequestTrackerLib;
using RequestTrackerBLLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackTest
{
    public class DepartmentBL
    {
        IRepository<int, Department> repository;
        DepartmentBLService departmentService;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            departmentService = new DepartmentBLService(repository);
        }

        [Test]
        public void GetDepartmnetByNameTest()
        {
            //Action
            var department = departmentService.GetDepartmentByName("IT");
            //Assert
            Assert.AreEqual(1, department.Id);
        }
    }
}
