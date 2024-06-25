using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LGBTQ_Cinemedia_Back_End.Models;
using LGBTQ_Cinemedia_Back_End.DTO;
using Microsoft.EntityFrameworkCore;

namespace LGBTQ_Cinemedia_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        LgbtqcontentdbContext dbContext = new LgbtqcontentdbContext();

        [HttpPost]
        public async Task<IActionResult> AddMovie(CineDTO cineDTO)
        {
            Cinemedium newContent = new Cinemedium
            {
                Name = cineDTO.Name,
                Type = cineDTO.Type,
                Genre = cineDTO.Genre,
                Rating = cineDTO.Rating,
                Img = cineDTO.Img,
            };
            dbContext.Add(newContent);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction("GetAll", new { id = newContent.Id }, newContent);
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Cinemedium>>> GetAll(string? title, string? genre, string? type)
        {
            IQueryable<Cinemedium> query = dbContext.Cinemedia;
            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(c => EF.Functions.Like(c.Name, $"%{title}%"));
            }
            if (!string.IsNullOrWhiteSpace(genre))
            {
                query = query.Where(c => EF.Functions.Like(c.Genre, $"%{genre}%"));
            }
            if (!string.IsNullOrWhiteSpace(type))
            {
                query = query.Where(c => EF.Functions.Like(c.Type, $"%{type}%"));
            }
            List<Cinemedium> result = await query.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cinemedium>> GetById(int id)
        {
            Cinemedium content = await dbContext.Cinemedia.FindAsync(id);
            if (content == null) return NotFound();
            return Ok(content);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            Cinemedium result = await dbContext.Cinemedia.FindAsync(id);

            if (result == null) return NotFound();

            dbContext.Cinemedia.Remove(result);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, CineDTO cineDTO)
        {
            Cinemedium cine = await dbContext.Cinemedia.FindAsync(id);
            if (cine == null) return NotFound();
           cine.Name = cineDTO.Name;
            cine.Type = cineDTO.Type;
            cine.Genre = cineDTO.Genre;
            cine.Rating = cineDTO.Rating;
            cine.Img = cineDTO.Img;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

       
    }
}

