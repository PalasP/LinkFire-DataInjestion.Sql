using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataInjestion.Sql.Models;

namespace DataInjestion.Sql.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LinkFireReadController : ControllerBase
    {
        private readonly LinkFireDBContext _context;

        public LinkFireReadController(LinkFireDBContext context)
        {
            _context = context;
        }

        #region artist

        // GET: api/LinkFireRead
        [HttpGet("GetArtists")]
        //[Route("")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        // GET: api/LinkFireRead/5
        [HttpGet("GetArtists/{id}")]
        //[Route("")]
        public async Task<ActionResult<Artist>> GetArtist(long id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        #endregion
        #region Collectionmatches

        // GET: api/LinkFireRead        
        [HttpGet("GetCollectionmatches")]
        public async Task<ActionResult<IEnumerable<Collectionmatch>>> GetCollectionmatches()
        {
            return await _context.Collectionmatches.ToListAsync();
        }

        // GET: api/LinkFireRead/5
        
        [HttpGet("GetCollectionmatches/{id}")]
        public async Task<ActionResult<Collectionmatch>> GetCollectionmatch(long id)
        {
            var collectionmatch = await _context.Collectionmatches.FindAsync(id);

            if (collectionmatch == null)
            {
                return NotFound();
            }

            return collectionmatch;
        }

        #endregion
        #region Collections
        // GET: api/LinkFireRead
        [HttpGet("GetCollection")]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollections()
        {
            return await _context.Collections.ToListAsync();
        }

        // GET: api/LinkFireRead/5
        [HttpGet("GetCollection/{id}")]
        public async Task<ActionResult<Collection>> GetCollection(long id)
        {
            var collection = await _context.Collections.FindAsync(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        #endregion
        #region Artistcollections

        // GET: api/LinkFireRead
        [HttpGet("GetArtistcollection")]
        public async Task<ActionResult<IEnumerable<Artistcollection>>> GetArtistcollections()
        {
            return await _context.Artistcollections.ToListAsync();
        }

        // GET: api/LinkFireRead/5
        [HttpGet("GetArtistcollection/{id}")]
        public async Task<ActionResult<Artistcollection>> GetArtistcollection(long id)
        {
            var artistcollection = await _context.Artistcollections.FindAsync(id);

            if (artistcollection == null)
            {
                return NotFound();
            }

            return artistcollection;
        }
        #endregion
    }
}
