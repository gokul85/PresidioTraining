using HMS.DAL;
using HMS.Model;
using HMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace HMS.Test
{
    public class HMSServiceTest
    {
        IRepository<int, Doctor> _docrepository;
        IRepository<int, Patient> _patrepository;
        IRepository<int, Appointment> _apporepository;
        IService _service;
        [SetUp]
        public void Setup()
        {
            _docrepository = new DoctorRepository();
            _patrepository = new PatientRepository();
            _apporepository = new AppointmentRepository();
            _service = new HMSService(_docrepository,_patrepository, _apporepository);
        }

        public void AddDocPat()
        {
            Doctor doc1 = new Doctor() { Name = "Ram", Specialization = "Eye" };
            Doctor doc2 = new Doctor() { Name = "Raj", Specialization = "Child" };
            Doctor doc3 = new Doctor() { Name = "Rahul", Specialization = "Eye" };
            _docrepository.Add(doc1);
            _docrepository.Add(doc2);
            _docrepository.Add(doc3);
            Patient pat1 = new Patient() { Name = "Ramu" };
            Patient pat2 = new Patient() { Name = "Raju" };
            Patient pat3 = new Patient() { Name = "Ramesh" };
            _patrepository.Add(pat1);
            _patrepository.Add(pat2);
            _patrepository.Add(pat3);
            _service.CreateAppointment(doc1, pat1, DateTime.Now);
            _service.CreateAppointment(doc2, pat2, DateTime.Now);
            _service.CreateAppointment(doc3, pat3, DateTime.Now);
        }

        [TestCase(1,1)]
        [TestCase(2,2)]
        [TestCase(3,3)]
        public void CreateAppiontment_Pass(int docid, int patid)
        {
            //Arrange
            AddDocPat();
            var doc = _docrepository.Get(docid);
            var pat = _patrepository.Get(patid);
            var appointmentdate = DateTime.Now;
            //Action
            var result = _service.CreateAppointment(doc, pat, appointmentdate);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(doc, result.Doctor);
            Assert.AreEqual(pat, result.Patient);
            Assert.AreEqual(appointmentdate, result.AppointmentDateTime);
        }
        //[TestCase(1, 2)]
        //[TestCase(3, 2)]
        //[TestCase(2, 3)]
        //public void CreateAppiontment_Fail(int docid, int patid)
        //{
        //    //Arrange
        //    AddDocPat();
        //    var doc = _docrepository.Get(docid);
        //    var pat = _patrepository.Get(patid);
        //    var appointmentdate = DateTime.Now;
        //    //Action
        //    _service.CreateAppointment(doc, pat, appointmentdate);
        //    var result = _service.CreateAppointment(doc, pat, appointmentdate);
        //    //Assert
        //    Assert.IsNull(result);
        //}

        [Test]
        public void CreateAppiontment_Exception()
        {
            var patient = _patrepository.Get(2);
            var appointmentDateTime = DateTime.Now;

            Assert.Throws<DoctorNotFoundException>(() => _service.CreateAppointment(new Doctor(), patient, appointmentDateTime));
        }
        [Test]
        public void GetAllAppointmentsTest()
        {
            AddDocPat();
            var result = _service.GetAllAppointments();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void AddDoctorTest_Pass()
        {
            var doc = new Doctor() { Name = "Rahul", Specialization = "Eye" };
            var result = _service.AddDoctor(doc);
            Assert.AreEqual(doc, result);
        }
        [Test]
        public void AddDoctorTest_Exception()
        {
            var exception = Assert.Throws<Exception>(()=> _service.AddDoctor(new Doctor()));
            Assert.AreEqual("Doctor is empty", exception.Message);
        }
        [Test]
        public void GetAllDoctorsTest()
        {
            AddDocPat();
            var result = _service.GetAllDoctors();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        [Test]
        public void UpdateDoctorTest_Pass()
        {
            var doc = new Doctor() { Name = "Rahul", Specialization = "Eye" };
            _service.AddDoctor(doc);
            doc.Name = "Raj";
            var result = _service.UpdateDoctor(doc);
            Assert.AreEqual(doc, result);
        }
        [Test]
        public void UpdateDoctorTest_Exception()
        {
            var exception = Assert.Throws<Exception>(() => _service.UpdateDoctor(new Doctor()));
            Assert.AreEqual("Updated Doctor is empty", exception.Message);
        }
        [Test]
        public void AddPatientTest_Pass()
        {
            var patient = new Patient() { Name = "Rahul"};
            var result = _service.AddPatient(patient);
            Assert.AreEqual(patient, result);
        }
        [Test]
        public void AddPatientTest_Exception()
        {
            var exception = Assert.Throws<Exception>(() => _service.AddPatient(new Patient()));
            Assert.AreEqual("Patient is empty", exception.Message);
        }
        [Test]
        public void GetAllPatientsTest()
        {
            AddDocPat();
            var result = _service.GetAllPatients();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
        [Test]
        public void UpdatePatientTest_Pass()
        {
            var patient = new Patient() { Name = "Rahul" };
            _service.AddPatient(patient);
            patient.Name = "Raj";
            var result = _service.UpdatePatient(patient);
            Assert.AreEqual(patient, result);
        }
        [Test]
        public void UpdatePatientTest_Exception()
        {
            var exception = Assert.Throws<Exception>(() => _service.UpdatePatient(new Patient()));
            Assert.AreEqual("Updated Patient is empty", exception.Message);
        }
        [Test]
        public void UpdateAppointment_Pass()
        {
            AddDocPat();
            var result = _service.UpdateAppointment(1,DateTime.Now);
            Assert.IsNotNull(result);
        }
        [Test]
        public void UpdateAppointment_Fail()
        {
            AddDocPat();
            var result = _service.UpdateAppointment(4, DateTime.Now);
            Assert.IsNull(result);
        }
        [Test]
        public void GetAllAppoinmentByDoctor_Pass()
        {
            AddDocPat();
            var result = _service.GetAllAppointmentsByDoctor(1);
            Assert.AreNotEqual(0,result.Count);
        }
        [Test]
        public void GetAllAppoinmentByDoctor_Fail()
        {
            AddDocPat();
            var result = _service.GetAllAppointmentsByDoctor(4);
            Assert.AreEqual(0,result.Count);
        }
        [Test]
        public void GetAllAppoinmentByPatient_Pass()
        {
            AddDocPat();
            var result = _service.GetAllAppointmentsByPatient(1);
            Assert.AreNotEqual(0, result.Count);
        }
        [Test]
        public void GetAllAppoinmentByPatient_Fail()
        {
            AddDocPat();
            var result = _service.GetAllAppointmentsByPatient(4);
            Assert.AreEqual(0, result.Count);
        }
    }
}
