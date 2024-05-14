using DoctorPatient.Models;
using DoctorPatient.Interfaces;
using DoctorPatient.Context;
using Microsoft.EntityFrameworkCore;
using DoctorPatient.Exceptions;

namespace DoctorPatient.Repository
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        public readonly DoctorPatientContext _context;

        public DoctorRepository(DoctorPatientContext context)
        {
            _context = context;
        }

        public async Task<Doctor> Add(Doctor doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public Task<Doctor> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> Get(int key)
        {
            var doctors = await _context.Doctors.FirstOrDefaultAsync(e => e.DocId == key);
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();
        }


        public async Task<Doctor> Update(Doctor doctor)
        {
            var updateddoc = await Get(doctor.DocId);
            if (updateddoc != null)
            {
                _context.Update(updateddoc);
                await _context.SaveChangesAsync(true);
                return doctor;
            }
            throw new NoSuchDoctorFoundException();
        }
    }
}
