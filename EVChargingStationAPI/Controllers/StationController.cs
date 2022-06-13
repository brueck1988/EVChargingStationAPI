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
        [HttpGet("{id}")]
        public async Task<ActionResult<Station>> Get(int id)
        {
            var station = await _context.Stations.FindAsync(id);
            if (station == null)
                return BadRequest("Station not found.");
            return Ok(station);
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
        [HttpPut]
        public async Task<ActionResult<List<Station>>> UpdateStation(Station request)
        {
            var dbStation = await _context.Stations.FindAsync(request.Id);
            if (dbStation == null)
                return BadRequest("Station not found.");
            dbStation.ApiId = request.ApiId;
            await _context.SaveChangesAsync();
            return Ok(await _context.Stations.ToListAsync());
        }

        // DELETE: api/Station/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
