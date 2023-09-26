using CarSalesApp.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp
{
    public class VehiclesRepository : IVehicle
    {
        private readonly IDbConnection _conn;

        public VehiclesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Vehicles> GetAllVehicles()
        {
            return _conn.Query<Vehicles>("SELECT * FROM car_app.car_data;");
        }       

        public Vehicles GetVehicle(int id)
        {
            return _conn.QuerySingle<Vehicles>("SELECT * FROM car_app.car_data WHERE Vehicle_ID = @id", new { id = id });
        }

        public void InsertVehicle(Vehicles vehicleToInsert)
        {
            _conn.Execute("INSERT INTO car_app.car_data (MAKE, MODEL, YEAR, MILEAGE, PRICE, COLOR) " +
                          "VALUES (@Make, @Model, @Year, @Mileage, @Price, @Color);",
                new
                {
                    Make = vehicleToInsert.Make,
                    Model = vehicleToInsert.Model,
                    Year = vehicleToInsert.Year,
                    Mileage = vehicleToInsert.Mileage,
                    Price = vehicleToInsert.Price,
                    Color = vehicleToInsert.Color
                });
        }
        public void UpdateVehicle(Vehicles vehicle)
        {
            _conn.Execute("UPDATE car_data SET Price = @price WHERE Vehicle_ID = @id", 
                new { price = vehicle.Price, id = vehicle.Vehicle_ID });
        }
        


        public void DeleteVehicle(Vehicles vehicle)
        {
            _conn.Execute("DELETE FROM car_app.car_data WHERE Vehicle_ID = @id;", new { id = vehicle.Vehicle_ID });                
        }
        public IEnumerable<CarMakes> GetMakes()
        {
            return _conn.Query<CarMakes>("SELECT title FROM car_app.make;");
        }
        
        public IEnumerable<CarModels> GetModels()
        {
            return _conn.Query<CarModels>("SELECT title FROM car_app.model;");
        }

        public IEnumerable<CarMakes> AssignCarMake()
        {
            var makeList = GetMakes();
            var vehicleMake = new Vehicles();
            return vehicleMake.Makes = makeList;

            //return vehicleMake;
        }

        public IEnumerable<CarModels> AssignCarModel()
        {
            var modelList = GetModels();
            var vehicleModel = new Vehicles
            {
                Models = modelList
            };

            return vehicleModel.Models;
        }
    }    
}
