using BusinessLibrary.Model;
using DataAccessLibrary.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Service
{
  public interface IVehicleDetailService
    {
        //Task<List<VehicleDetailModel>> GetVehicleDetails();
        Task<bool> SaveVehicleDetails(VehicleDetail vehicleDetailModel);
        Task<bool> DeleteVehicleDetails(int vehicleDetailsId);
        Task<object> GetVehicleDetails();
    }
}
