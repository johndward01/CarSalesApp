using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSalesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesApp.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicle repo;

        public VehiclesController(IVehicle repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var vehicles = repo.GetAllVehicles();
            return View(vehicles);
        }

        public IActionResult ViewVehicle(int id)
        {
            var vehicle = repo.GetVehicle(id);
            return View(vehicle);
        }

        public IActionResult UpdateVehicle(int id)
        {
            Vehicles vehicle = repo.GetVehicle(id);

            repo.UpdateVehicle(vehicle);

            if (vehicle == null)

                return View("Vehicle Not Found");

            return View(vehicle);
        }

        public IActionResult UpdateVehicleToDatabase(Vehicles vehicle)
        {
            repo.UpdateVehicle(vehicle);

            return RedirectToAction("ViewVehicle", new { id = vehicle.Vehicle_ID });
        }        

        public IActionResult InsertVehicle()
        {
            var vehicle = new Vehicles();
            vehicle.Makes = repo.AssignCarMake();
            vehicle.Models = repo.AssignCarModel();
            
            return View(vehicle);
        }

        public IActionResult InsertVehicleToDatabase(Vehicles vehiclesToInsert)
        {
            repo.InsertVehicle(vehiclesToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteVehicle(Vehicles vehicle)
        {
            repo.DeleteVehicle(vehicle);

            return RedirectToAction("Index");
        }
    }
}