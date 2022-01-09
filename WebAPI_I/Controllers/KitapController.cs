using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI_I.Model;

namespace WebAPI_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        private readonly KutuphaneDBContext _context;
        public KitapController(KutuphaneDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var kitaplar = _context.Kitaplars.ToList();

            return Ok(kitaplar);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Kitaplar kitap = (from k in _context.Kitaplars.ToList()
            //            where k.KitapId == id
            //            select k).SingleOrDefault();

            var kitap = _context.Kitaplars.Find(id);

            return Ok(kitap);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Kitaplar kitap)
        {
           _context.Kitaplars.Add(kitap);
           await _context.SaveChangesAsync();

           return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody]Kitaplar kitap)
        {
            _context.Entry<Kitaplar>(kitap).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var kitap = _context.Kitaplars.Find(id);
            _context.Remove(kitap);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]JsonPatchDocument jsonDoc)
        {
            var kitap = _context.Kitaplars.Find(id);
            jsonDoc.ApplyTo(kitap);
            _context.SaveChanges();

            return Ok();
        }
    }
}
