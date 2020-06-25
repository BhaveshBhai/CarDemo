using DataAccessLibrary.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Service
{
   public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypes();
    }
}
