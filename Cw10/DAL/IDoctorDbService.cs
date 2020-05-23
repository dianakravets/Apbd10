using Cw10.DTOs.Request;
using Cw10.DTOs.Response;
using Cw10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DAL
{
   public  interface IDoctorDbService
    {
        String GetDoctor(int id);
        void DeleteDoctor(int id);
        ModifyDoctorResponse ModifyDoctor(int index, ModifyDoctorRequest request);
        Inserted InsertDoctor(ToInsert request);
    }
}
