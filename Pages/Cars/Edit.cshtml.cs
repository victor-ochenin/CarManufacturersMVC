using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Car? Car { get; set; }
        public string? Error { get; private set; }
        public SelectList ManufacturersOptions { get; set; } = null!;

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
                List<Manufacturer> manufacturers = await _db.Manufacturers.ToListAsync();
                ManufacturersOptions = new SelectList(manufacturers, "Id", "Name");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            Car edited = await _db.Cars.FirstAsync(c => c.Id == Car!.Id);

            edited.Name = Car!.Name;
            edited.Class = Car.Class;
            edited.Model = Car.Model;
            edited.Country = Car.Country;
            edited.ProductionYears = Car.ProductionYears;
            edited.PhotoUrl = Car.PhotoUrl;
            edited.ManufacturerId = Car.ManufacturerId;

            await _db.SaveChangesAsync();

            return RedirectToPage("/Cars/Index");
        }
    }
} 