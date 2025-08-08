using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarManufacturersMVC.Data;
using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Pages.Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
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
    }
}


