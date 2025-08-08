using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Car? Car { get; private set; }

        public string? Error { get; private set; }

        public async Task OnGet(int id)
        {
            Car? car = await _db.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                Error = $"Автомобиль с идентификатором '{id}' не найден";
            } else
            {
                Car = car;
            }
        }
    }
} 