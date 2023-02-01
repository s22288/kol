using kolokwium2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Controllers
{
    [ApiController]
    [Route("/api/actions")]
    public class MusicController : Controller
    {
        private readonly dbContext _context;

      
        public MusicController(dbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Musician>> GetMusician(int id)
        {
            var musician = await _context.Musicians
                .Include(m => m.Musician_Tracks)
                .ThenInclude(mt => mt.Track)
                .FirstOrDefaultAsync(m => m.IdMusician == id);

            if (musician == null)
            {
                return NotFound();
            }

            var musicianDetails = new
            {
                IdMusician = musician.IdMusician,
                FirstName = musician.FirstName,
                Tracks = musician.Musician_Tracks
         .OrderBy(mt => mt.Track.Duration)
         .Select(mt => new
         {
             IdTrack = mt.Track.IdTrack,
             TrackName = mt.Track.TrackName,
             Duration = mt.Track.Duration
         })
         .ToList()
            };


            return Ok(musicianDetails);
        }
    }

}
