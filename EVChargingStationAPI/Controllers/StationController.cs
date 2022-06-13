using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly DataContext _context;

        public StationController(DataContext context)
        {
            _context = context;
        }
        
        // GET: api/Station
        [HttpGet]
        public async Task<ActionResult<List<Station>>> Get()
        {
            return Ok(await _context.Stations.ToListAsync());
        }

        // GET: api/Station/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Station
        [HttpPost]
        public async Task<ActionResult<List<Station>>> AddHero(Station station)
        {
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();

            return Ok(await _context.Stations.ToListAsync());
        }

        // PUT: api/Station/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Station/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
