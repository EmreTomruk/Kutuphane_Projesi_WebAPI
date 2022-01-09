using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
        {
            string[] mesaj = { "Bu", "çok", "gizli", "bir", "mesajdir", "..." };

            return Ok(mesaj);
        }
    }
}
