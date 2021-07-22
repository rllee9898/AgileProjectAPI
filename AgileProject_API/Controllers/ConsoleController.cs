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
    public class ConsoleController : ApiController
    {
        private readonly ApplicationDbContext _consoles = new ApplicationDbContext();
        //crud /pgpd

        //post
        public ConsoleController()
        {
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 1, ConsoleType = "Xbox360" });
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 2, ConsoleType = "XboxOne" });
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 3, ConsoleType = "XboxSeriesX" });
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 4, ConsoleType = "PlayStation3" });
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 5, ConsoleType = "PlayStation4" });
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 6, ConsoleType = "PlayStation5" });
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 7, ConsoleType = "NintendoWii" });
            _consoles.Consoles.Add(new AgileProject.Data.Console { ConsoleId = 8, ConsoleType = "NintendoSwitch" });
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(AgileProject.Data.Console console)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _consoles.Consoles.Add(console);
            await _consoles.SaveChangesAsync();
            return Ok($"{console.ConsoleType} was added");
        }

        //get
        //get all
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<AgileProject.Data.Console> consoles = await _consoles.Consoles.ToListAsync();
            return Ok(consoles);
        }
    }
}
