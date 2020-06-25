using BusinessLibrary.Model;
using DataAccessLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Service
{
   public class VehicleTypeService :IVehicleTypeService
    {
        private readonly CarsaleDBContext db = new CarsaleDBContext();

        public async Task<IEnumerable<VehicleType>> GetVehicleTypes()
        {
            try
            {
                var vehicles = await db.VehicleType.ToListAsync();
                return vehicles;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
