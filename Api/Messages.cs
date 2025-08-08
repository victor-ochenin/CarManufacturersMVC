using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManufacturersMVC.Api
{
    public record StringMessage(string Message);
    public record ManufacturerMessage(int Id, string Name, string Country);
    public record CarHeaderMessage(string Name, string Uri);
    public record CarMessage(
        int Id,
        string Name,
        string Class,
        string Model,
        string Country,
        string ProductionYears,
        string? PhotoUrl,
        ManufacturerMessage manufacturer
    );
    public record CarFormMessage(
        string Name,
        string Class,
        string Model,
        string Country,
        string ProductionYears,
        string? PhotoUrl,
        int ManufacturerId
    );
    public record ManufacturerFormMessage(
        string Name,
        string Country
    );
} 