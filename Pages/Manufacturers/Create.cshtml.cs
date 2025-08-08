using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Manufacturers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public string? Error { get; private set; }

        public async Task<IActionResult> OnPost(string name, string country, string? photoUrl)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(country))
            {
                Error = "Название и страна производителя обязательны для заполнения.";
                return Page();
            }

            Manufacturer newManufacturer = new Manufacturer() { 
                Name = name, 
                Country = country,
                PhotoUrl = string.IsNullOrWhiteSpace(photoUrl) ? null : photoUrl
            };
            
            await _db.Manufacturers.AddAsync(newManufacturer);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Manufacturers/Index");
        }
    }
}
