using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public SelectList ManufacturersOptions { get; set; } = null!;

        public async Task OnGet()
        {
            List<Manufacturer> manufacturers = await _db.Manufacturers.ToListAsync();
            ManufacturersOptions = new SelectList(manufacturers, "Id", "Name");
        }

        [BindProperty]
        public Car NewCar { get; set; } = new();

        public async Task<IActionResult> OnPost()
        {
            await _db.AddAsync(NewCar);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Cars/Index");
        }
    }
} 