using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BupaApp.Models;

namespace BupaApp.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(string plate);
    }
}