using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie.Data;
using Movie.Models;
using SQLitePCL;

namespace Movie.Controllers
{
    [Route("[controller]")]
    public class PeliculasController : Controller
    {
        private readonly ILogger<PeliculasController> _logger;
        private readonly DataContext _context;

        public PeliculasController(ILogger<PeliculasController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet(Name = "GetPeliculas")]//metodo opbetencion de data
        public async Task<ActionResult<IEnumerable<CMovie>>> GetPeliculas(){

           var Peliculas = await _context.TMovie.ToListAsync();
            return Ok(Peliculas);
        }
        [HttpGet("{id}", Name = "GetPeliculaId")]//obtner por id
       public async Task<ActionResult<CMovie>> GetPeliculas(int id)
       {
            
         var Pelicula = await _context.TMovie.FindAsync(id);//el primero que encuentroi el find
         if(Pelicula == null)
         {
            return NotFound();//404
         }
            return Ok(Pelicula);

       }
//CREAR
       [HttpPost]
       public async Task<ActionResult<CMovie>> Post(CMovie Pelicula)
       {
        _context.Add(Pelicula);
        await _context.SaveChangesAsync();
        return new CreatedAtRouteResult("GetPeliculaId", new { id = Pelicula.Id }, Pelicula);
       }
//ACTUALIZAR
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CMovie Pelicula)//campo
        {
            if(id!= Pelicula.Id)
            {
                return BadRequest();
            }
            _context.Entry(Pelicula).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CMovie>> Delete(int id)
        {
            var Pelicula = await _context.TMovie.FindAsync(id);
            if(Pelicula == null)
            {
                return NotFound();
            }
            _context.TMovie.Remove(Pelicula);
            await _context.SaveChangesAsync();
             return Pelicula;
        }







       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}