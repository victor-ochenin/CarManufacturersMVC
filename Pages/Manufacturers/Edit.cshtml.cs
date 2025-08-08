using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Manufacturers
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Manufacturer? Manufacturer { get; private set; }
        public string? Error { get; private set; }

        public async Task OnGet(int id)
        {
            Manufacturer? manufacturer = await _db.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturer == null)
            {
                Error = $"Производитель с идентификатором '{id}' не найден";
            }
            else
            {
                Manufacturer = manufacturer;
            }
        }

        public async Task<IActionResult> OnPost(int id, string name, string country, string? photoUrl)
        {
            Manufacturer manufacturer = await _db.Manufacturers.FirstAsync(m => m.Id == id);

            manufacturer.Name = name;
            manufacturer.Country = country;
            manufacturer.PhotoUrl = string.IsNullOrWhiteSpace(photoUrl) ? null : photoUrl;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Manufacturers/Index");
        }
    }
}


