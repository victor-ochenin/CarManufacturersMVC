using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Api
{
    [Route("api/manufacturer")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ManufacturersController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET http://localhost:5000/api/manufacturer
        [HttpGet]
        public async Task<List<ManufacturerMessage>> ListAll()
        {
            List<Manufacturer> manufacturers = await _db.Manufacturers.ToListAsync();

            List<ManufacturerMessage> manufacturerMessages = manufacturers.Select(m => new ManufacturerMessage(
                Id: m.Id,
                Name: m.Name,
                Country: m.Country
            )).ToList();

            return manufacturerMessages;
        }

        // GET http://localhost:5000/api/manufacturer/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Manufacturer? manufacturer = await _db.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound(new StringMessage($"manufacturer '{id}' not found"));
            }

            ManufacturerMessage message = new ManufacturerMessage(
                Id: id,
                Name: manufacturer.Name,
                Country: manufacturer.Country
            );
            return Ok(message);
        }

        // POST http://localhost:5000/api/manufacturer
        [HttpPost]
        public async Task<IActionResult> Create(ManufacturerFormMessage message)
        {
            if (string.IsNullOrEmpty(message.Name))
            {
                return BadRequest(new StringMessage("name cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Country))
            {
                return BadRequest(new StringMessage("country cannot be empty"));
            }

            bool isNameExists = await _db.Manufacturers
                .Where(m => m.Name == message.Name)
                .AnyAsync();
            if (isNameExists)
            {
                return BadRequest(new StringMessage($"manufacturer with name '{message.Name}' already exists"));
            }

            Manufacturer manufacturer = new Manufacturer()
            {
                Name = message.Name,
                Country = message.Country
            };

            await _db.Manufacturers.AddAsync(manufacturer);
            await _db.SaveChangesAsync();

            ManufacturerMessage result = new ManufacturerMessage(
                Id: manufacturer.Id,
                Name: manufacturer.Name,
                Country: manufacturer.Country
            );
            return Ok(result);
        }

        // PATCH http://localhost:5000/api/manufacturer/{id}
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Edit(int id, ManufacturerFormMessage message)
        {
            Manufacturer? manufacturer = await _db.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound(new StringMessage($"manufacturer '{id}' not found"));
            }

            if (string.IsNullOrEmpty(message.Name))
            {
                return BadRequest(new StringMessage("name cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Country))
            {
                return BadRequest(new StringMessage("country cannot be empty"));
            }

            bool isNameExists = await _db.Manufacturers
                .Where(m => m.Name == message.Name && m.Id != id)
                .AnyAsync();
            if (isNameExists)
            {
                return BadRequest(new StringMessage($"manufacturer with name '{message.Name}' already exists"));
            }

            manufacturer.Name = message.Name;
            manufacturer.Country = message.Country;

            await _db.SaveChangesAsync();

            ManufacturerMessage result = new ManufacturerMessage(
                Id: manufacturer.Id,
                Name: manufacturer.Name,
                Country: manufacturer.Country
            );
            return Ok(result);
        }

        // DELETE http://localhost:5000/api/manufacturer/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Manufacturer? manufacturer = await _db.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                return NotFound(new StringMessage($"manufacturer '{id}' not found"));
            }

            bool hasRelatedCars = await _db.Cars
                .Where(c => c.ManufacturerId == id)
                .AnyAsync();
            if (hasRelatedCars)
            {
                return BadRequest(new StringMessage($"cannot delete manufacturer '{id}' - it has related cars"));
            }

            _db.Manufacturers.Remove(manufacturer);
            await _db.SaveChangesAsync();

            return Ok(new StringMessage($"manufacturer '{id}' deleted"));
        }
    }
} 