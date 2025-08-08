using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Manufacturers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Manufacturer? Manufacturer { get; private set; }
        public string? Error { get; private set; }
        public bool HasRelatedCars { get; private set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Manufacturer = await _db.Manufacturers
                .Include(m => m.Cars)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Manufacturer == null)
            {
                Error = "Производитель не найден.";
                return Page();
            }

            HasRelatedCars = Manufacturer.Cars.Any();
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Manufacturer = await _db.Manufacturers
                .Include(m => m.Cars)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Manufacturer == null)
            {
                Error = "Производитель не найден.";
                return Page();
            }

            // Удаляем связанные автомобили
            if (Manufacturer.Cars.Any())
            {
                _db.Cars.RemoveRange(Manufacturer.Cars);
            }

            // Удаляем производителя
            _db.Manufacturers.Remove(Manufacturer);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Manufacturers/Index");
        }
    }
}
