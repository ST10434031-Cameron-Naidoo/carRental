using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarRental.Dal;
using CarRental.Application;


namespace CarRental.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly VehicleDBContext _vehicleDBContext;
    private readonly VehicleDBService _vehicleDbService;


    public HomeController(ILogger<HomeController> logger,VehicleDBContext dBContext, VehicleDBService vehicleDBService)
    {
        _logger = logger;
        _vehicleDBContext = dBContext;
        _vehicleDbService = vehicleDBService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Vehicle()
    {
        var vehicles = _vehicleDbService.getAllVehicles();
        return View(vehicles);
    }

    public IActionResult addEditVehicle(int? id)
    {
        if (id == null) return View(new Vehicle());

        var vehicle = _vehicleDbService.getAllVehicles()
                                       .SingleOrDefault(v => v.ID == id);
        return View(vehicle);
    }

    public IActionResult addEditVehicleForm(Vehicle v)
    {
        if (v.ID == 0)
            _vehicleDbService.addVehicle(v);
        else
            _vehicleDbService.updateVehicle(v);

        return RedirectToAction("Vehicle");
    }

    public IActionResult deleteVehicle(Vehicle v)
    {
        _vehicleDbService.deleteVehicle(v.ID);
        return RedirectToAction("Vehicle");
    }

}
