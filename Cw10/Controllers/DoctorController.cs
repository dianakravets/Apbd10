using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.DAL;
using Cw10.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorDbService _service;
        public DoctorController(IDoctorDbService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var res = _service.GetDoctor(id);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound("Nie ma takiego studenta");
            }
        }
        [HttpDelete("{id}")]
        public void DeleteDoctor(int id)
        {
            _service.DeleteDoctor(id);
        }

        [HttpPut("{index}")]
        public IActionResult ModifyDoctor(int index, ModifyDoctorRequest request)
        {

            var res = _service.ModifyDoctor(index, request);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound("Not found");
            }
        }
        [HttpPost]
        public IActionResult InsertDoctor(ToInsert request)
        {


            var res = _service.InsertDoctor(request);

            if (res != null)
            {
                return Created("", res);
            }
            else
            {
                return BadRequest();
            }



        }
    }
}