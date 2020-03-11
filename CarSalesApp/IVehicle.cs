using CarSalesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp
{
    public interface IVehicle
    {
        public IEnumerable<Vehicles> GetAllVehicles();
        public Vehicles GetVehicle(int id);
        public void UpdateVehicle(Vehicles vehicle);
        public void InsertVehicle(Vehicles vehicleToInsert);
        public IEnumerable<CarMakes> GetMakes();
        public IEnumerable<CarModels> GetModels();
        public IEnumerable<CarMakes> AssignCarMake();
        public IEnumerable<CarModels> AssignCarModel();
        public void DeleteVehicle(Vehicles vehicle);
    }
}
