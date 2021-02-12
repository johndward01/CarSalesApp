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
        private readonly IVehicle _repository;

        public VehiclesController(IVehicle repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            var vehicles = _repository.GetAllVehicles();
            return View(vehicles);
        }

        public IActionResult ViewVehicle(int id)
        {
            var vehicle = _repository.GetVehicle(id);
            return View(vehicle);
        }

        public IActionResult UpdateVehicle(int id)
        {
            Vehicles vehicle = _repository.GetVehicle(id);

            //_repository.UpdateVehicle(vehicle);

            if (vehicle == null)

                return View("Vehicle Not Found");

            return View(vehicle);
        }

        public IActionResult UpdateVehicleToDatabase(Vehicles vehicle)
        {
            _repository.UpdateVehicle(vehicle);

            return RedirectToAction("ViewVehicle", new { id = vehicle.Vehicle_ID });
        }        

        public IActionResult InsertVehicle()
        {
            var vehicle = new Vehicles();
            vehicle.Makes = _repository.AssignCarMake();
            vehicle.Models = _repository.AssignCarModel();
            
            return View(vehicle);
        }

        public IActionResult InsertVehicleToDatabase(Vehicles vehiclesToInsert)
        {
            _repository.InsertVehicle(vehiclesToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteVehicle(Vehicles vehicle)
        {
            _repository.DeleteVehicle(vehicle);

            return RedirectToAction("Index");
        }
    }
}