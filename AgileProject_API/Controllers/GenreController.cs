using AgileProject.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AgileProject_API.Controllers
{
    public class GenreController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //CRUD / PGPD
        //Post

        [HttpPost]
        public async Task<IHttpActionResult> Post(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return Ok($"{genre.Name} was added");
        }

        //Get
        //Get All

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Genre> genres = await _context.Genres.ToListAsync();
            return Ok(genres);
        }

        //Get by SKU
        [HttpGet]
        public async Task<IHttpActionResult> GetByID([FromUri]int id)
        {
            Genre genre = await _context.Genres.FindAsync(id);

            if (genre != null)
            {
                return Ok(genre);
            }
            return NotFound();
        }



        /*            //Update = Put
                    [HttpPut]
                    public async Task<IHttpActionResult> UpdateProduct([FromUri] string sku, [FromBody] Product model)
                    {
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        Genre product = await _context.Genres.FindAsync(sku);
                        if (product == null)
                        {
                            return NotFound();
                        }

                        if (product.SKU != model.SKU)
                        {
                            return BadRequest("Product SKU Missmatch");
                        }

                        //_context.Entry(model).State = EntityState.Modified;
                        //Does the same thing as setting properties individually
                        product.Name = model.Name;
                        product.NumberInStock = model.NumberInStock;
                        product.Cost = model.Cost;
                        //product.IsInStock = model.IsInStock;

                        await _context.SaveChangesAsync();
                        return Ok();

                    }

                    //Delete
                    [HttpDelete]
                    public async Task<IHttpActionResult> Delete([FromUri] string sku)
                    {
                        Product product = await _context.Products.FindAsync(sku);

                        if (product == null)
                        {
                            return NotFound();
                        }

                        _context.Products.Remove(product);
                        await _context.SaveChangesAsync();
                        return Ok($"{product.Name} was removed from the DB");
                    }

                }*/
    }
}


