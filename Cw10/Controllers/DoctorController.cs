using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly CodeFirstContext _context;
        public DoctorController(CodeFirstContext context)
        {
            _context = context;
        }



       [HttpGet]
       public IActionResult GetDoctor()
        {
            return Ok();
        }
    }
}