using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly CarService _carService;

    public List<Car> Cars { get; set; } = new();

    public IndexModel(CarService carService)
    {
        _carService = carService;
    }

    public async Task OnGetAsync()
    {
        Cars = await _carService.GetCarsAsync();
    }
}