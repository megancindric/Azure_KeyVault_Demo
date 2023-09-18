using AzureKeyVaultDemo.Data;
using AzureKeyVaultDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureKeyVaultDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public IActionResult Get()
        {
            var allPets = _context.Pets.ToList();
            return Ok(allPets);
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        // POST api/<PetsController>
        [HttpPost]
        public IActionResult Post([FromBody] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Pets.Add(pet);
                _context.SaveChanges();
                return StatusCode(201, pet);
            }
            return BadRequest(ModelState); 
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pet pet)
        {
            var petToUpdate = _context.Pets.Find(id);
            if (petToUpdate == null)
            {
                return NotFound();
            }
            petToUpdate.Name = pet.Name;
            petToUpdate.Notes = pet.Notes;
            petToUpdate.Species = pet.Species;
            petToUpdate.Birthday = pet.Birthday;
            petToUpdate.Color = pet.Color;
            _context.Pets.Update(petToUpdate);
            _context.SaveChanges();
            return Ok(petToUpdate);
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            _context.Pets.Remove(pet);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
