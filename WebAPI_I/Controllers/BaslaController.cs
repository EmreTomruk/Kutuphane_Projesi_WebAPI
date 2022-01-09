using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_I.Controllers
{
    // [Route("api/[controller]")]
    [Route("servis/[controller]")]
    [ApiController]
    public class BaslaController : ControllerBase
    {
        [HttpGet]
        public string Deneme()
        {
            return "Deneme 123";
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("Emened" + id);
        }

        //[Route("city")]
        [HttpGet("cities")]
        public IActionResult GetCities()
        {
            string[] cities = { "Londra", "Paris", "Madrid", "Ankara" };
            return Ok(cities);
        }

        [HttpGet("test")]
        public IActionResult Get()
        {
            
            return Ok();    //200
            //return BadRequest(); //400
            //return NotFound();   //404
            //return Unauthorized(); //401
        }
    }
}
