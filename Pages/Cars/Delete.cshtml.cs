using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Car? Car { get; private set; }

        public string? Error { get; private set; }

        public async Task OnGet(int id)
        {
            Car? car = await _db.Cars
                .FirstOrDefaultAsync(c => c.Id == id);
            if (car == null)
            {
                Error = $"Автомобиль с идентификатором '{id}' не найден";
            }
            else
            {
                Car = car;
            }
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Car deleted = await _db.Cars.FirstAsync(c => c.Id == id);
            _db.Cars.Remove(deleted);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Cars/Index");
        }
    }
} 