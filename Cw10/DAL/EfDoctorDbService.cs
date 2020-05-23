using Cw10.DTOs.Request;
using Cw10.DTOs.Response;
using Cw10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DAL
{
   

    public class EfDoctorDbService : IDoctorDbService
    {
        private readonly CodeFirstContext _context;

        public EfDoctorDbService(CodeFirstContext context)
        {
            _context = context;
        }

        public String GetDoctor(int id)
        {
            var res = _context.Doctor.Where(d=>d.IdDoctor==id).Select(i=>new { i.FirstName,i.LastName,i.Email}).ToString();
            
            return res;

        }
        public void DeleteDoctor(int id)
        {
            var tmp = _context.Doctor.Find(id);
            if (_context.Prescription.Select(i => i.IdDoctor).First() == id)
            {
                var x = _context.Prescription.Where(o => o.IdDoctor == id);
                var y = x.Select(i => i.IdPrescription).First();
                if (_context.PrescriptionMedicament.Select(i => i.IdPrescription).First() == y)
                {
                    var z = _context.PrescriptionMedicament.Where(i=>i.IdPrescription==y);
                    _context.PrescriptionMedicament.Remove(_context.PrescriptionMedicament.Find(z));
                    _context.Prescription.Remove(_context.Prescription.Find(x));
                }
            }
            else
            {
                
                _context.Doctor.Remove(tmp);
            }

            _context.SaveChanges();
        }

        public ModifyDoctorResponse ModifyDoctor(int index, ModifyDoctorRequest request)
        {
            var doctor = _context.Doctor.Find(index);
            if (doctor == null)
            {
                return null;
            }
            else
            {
                doctor.FirstName = request.FirstName;
                doctor.LastName = request.LastName;
                doctor.Email = request.Email;
                _context.SaveChanges();

                ModifyDoctorResponse response = new ModifyDoctorResponse();
                response.IdDoctor = doctor.IdDoctor;
                response.FirstName = doctor.FirstName;
                response.LastName = doctor.LastName;
                response.Email = doctor.Email;
                return response;
            }
        }

        public Inserted InsertDoctor(ToInsert request)
        {
            Inserted res = new Inserted();
            var d = _context.Doctor.Find(request.IdDoctor);
            if (d != null)
            {
               var id = _context.Doctor.Max(i => i.IdDoctor) + 1;
                var doctor = new Doctor { IdDoctor = id, FirstName = request.FirstName, LastName = request.LastName, Email = request.Email };
                _context.Doctor.Add(doctor);
                _context.SaveChanges();

                res.IdDoctor = doctor.IdDoctor;
                res.FirstName = doctor.FirstName;
                res.LastName = doctor.LastName;
                res.Email = doctor.Email;
                return res;

            }
            else
            {

                var doc = new Doctor { IdDoctor = request.IdDoctor, FirstName = request.FirstName, LastName = request.LastName, Email = request.Email };
                _context.Doctor.Add(doc);
                _context.SaveChanges();

                res.IdDoctor = doc.IdDoctor;
                res.FirstName = doc.FirstName;
                res.LastName = doc.LastName;
                res.Email = doc.Email;
                return res;
            }
        }
    }
}
