using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Api
{
    [Route("api/car")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CarsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET http://localhost:5000/api/car
        [HttpGet]
        public async Task<List<CarHeaderMessage>> ListAll()
        {
            List<Car> cars = await _db.Cars.ToListAsync();

            List<CarHeaderMessage> carHeaders = cars.Select(car => new CarHeaderMessage(
                Name: car.Name,
                Uri: $"{Request.Scheme}://{Request.Host}/api/car/{car.Id}"
            )).ToList();

            return carHeaders;
        }

        // GET http://localhost:5000/api/car/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Car? car = await _db.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new StringMessage($"car '{id}' not found"));
            }

            CarMessage message = new CarMessage(
                Id: id,
                Name: car.Name,
                Class: car.Class,
                Model: car.Model,
                Country: car.Country,
                ProductionYears: car.ProductionYears,
                PhotoUrl: car.PhotoUrl,
                manufacturer: new ManufacturerMessage(
                    Id: car.Manufacturer!.Id,
                    Name: car.Manufacturer!.Name,
                    Country: car.Manufacturer!.Country
                )
            );
            return Ok(message);
        }

        // POST http://localhost:5000/api/car
        [HttpPost]
        public async Task<IActionResult> Create(CarFormMessage message)
        {
            if (string.IsNullOrEmpty(message.Name))
            {
                return BadRequest(new StringMessage("name cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Class))
            {
                return BadRequest(new StringMessage("class cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Model))
            {
                return BadRequest(new StringMessage("model cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Country))
            {
                return BadRequest(new StringMessage("country cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.ProductionYears))
            {
                return BadRequest(new StringMessage("production years cannot be empty"));
            }

            bool isManufacturerExists = await _db.Manufacturers
                .Where(m => m.Id == message.ManufacturerId)
                .AnyAsync();
            if (!isManufacturerExists)
            {
                return NotFound(new StringMessage($"manufacturer '{message.ManufacturerId}' not found"));
            }

            Car car = new Car()
            {
                Name = message.Name,
                Class = message.Class,
                Model = message.Model,
                Country = message.Country,
                ProductionYears = message.ProductionYears,
                PhotoUrl = message.PhotoUrl,
                ManufacturerId = message.ManufacturerId
            };

            await _db.Cars.AddAsync(car);
            await _db.SaveChangesAsync();

            CarHeaderMessage header = new CarHeaderMessage(
                Name: car.Name,
                Uri: $"{Request.Scheme}://{Request.Host}/api/car/{car.Id}"
            );
            return Ok(header);
        }

        // PATCH http://localhost:5000/api/car/{id}
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Edit(int id, CarFormMessage message)
        {
            Car? car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new StringMessage($"car '{id}' not found"));
            }

            if (string.IsNullOrEmpty(message.Name))
            {
                return BadRequest(new StringMessage("name cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Class))
            {
                return BadRequest(new StringMessage("class cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Model))
            {
                return BadRequest(new StringMessage("model cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.Country))
            {
                return BadRequest(new StringMessage("country cannot be empty"));
            }

            if (string.IsNullOrEmpty(message.ProductionYears))
            {
                return BadRequest(new StringMessage("production years cannot be empty"));
            }

            bool isManufacturerExists = await _db.Manufacturers
                .Where(m => m.Id == message.ManufacturerId)
                .AnyAsync();
            if (!isManufacturerExists)
            {
                return NotFound(new StringMessage($"manufacturer '{message.ManufacturerId}' not found"));
            }

            car.Name = message.Name;
            car.Class = message.Class;
            car.Model = message.Model;
            car.Country = message.Country;
            car.ProductionYears = message.ProductionYears;
            car.PhotoUrl = message.PhotoUrl;
            car.ManufacturerId = message.ManufacturerId;

            await _db.SaveChangesAsync();

            CarHeaderMessage header = new CarHeaderMessage(
                Name: car.Name,
                Uri: $"{Request.Scheme}://{Request.Host}/api/car/{car.Id}"
            );
            return Ok(header);
        }

        // DELETE http://localhost:5000/api/car/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Car? car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                return NotFound(new StringMessage($"car '{id}' not found"));
            }

            _db.Cars.Remove(car);
            await _db.SaveChangesAsync();

            return Ok(new StringMessage($"car '{id}' deleted"));
        }
    }
} 