using AgileProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgileProject_API.Controllers
{
    public class GameController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //CRUD PGPD

        //Post
        [HttpPost]
        public async Task<IHttpActionResult> Post(Game game)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return Ok($"{ game.Title} was added");
        }

        //Delete
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] string sku)
        {
            Game game = await _context.Games.FindAsync(sku);
            if (game == null)
            {
                return NotFound();
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return Ok($"{game.Title} was removed from Database");
        }
    }
}
