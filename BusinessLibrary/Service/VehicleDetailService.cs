using BusinessLibrary.Model;
using DataAccessLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Service
{
    public class VehicleDetailService : IVehicleDetailService
    {
        private readonly CarsaleDBContext db = new CarsaleDBContext();

        public async Task<bool> DeleteVehicleDetails(int vehicleDetailsId)
        {
            try
            {
                var vehicleDetails = await db.VehicleDetail.FirstOrDefaultAsync(x => x.VehicleDetailsId == vehicleDetailsId);

                if (vehicleDetails != null)
                {
                    db.VehicleDetail.Remove(vehicleDetails);
                }
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<object> GetVehicleDetails()
        {
            try
            {
                var VehicleDetails = await (from vd in db.VehicleDetail
                                            join vt in db.VehicleType on vd.VehicleId equals vt.VehicleId
                                            join bt in db.BodyType on vd.BodyTypeId equals bt.BodyId
                                            select new VehicleDetailModel
                                            {
                                                BodyType = bt.BodyName,
                                                BodyTypeId =Convert.ToInt32(vd.BodyTypeId),
                                                Doors = Convert.ToInt32(vd.Doors),
                                                Engine = vd.Engine,
                                                Make = vd.Make,
                                                Model = vd.Model,
                                                VehicleId = Convert.ToInt32(vd.VehicleId),
                                                VehicleType = vt.Name,
                                                Wheels = Convert.ToInt32(vd.Wheels),
                                                VehicleDetailsId = Convert.ToInt32(vd.VehicleDetailsId)
                                            }).ToListAsync();
                return VehicleDetails;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> SaveVehicleDetails(VehicleDetail vehicleDetailModel)
        {
            try
            {
               
                    var vehicleDetail = db.VehicleDetail.Where
                             (x => x.VehicleDetailsId == vehicleDetailModel.VehicleDetailsId).FirstOrDefault();
                    if (vehicleDetail == null)
                    {
                    vehicleDetail = new VehicleDetail()
                    {
                        BodyTypeId = vehicleDetailModel.BodyTypeId,
                        Doors= vehicleDetailModel.Doors,
                        Engine= vehicleDetailModel.Engine,
                       Make= vehicleDetailModel.Make,
                       Model= vehicleDetailModel.Model,
                       VehicleId= vehicleDetailModel.VehicleId,
                       Wheels= vehicleDetailModel.Wheels
                    };
                        db.VehicleDetail.Add(vehicleDetail);

                    }
                    else
                    {
                    vehicleDetail.BodyTypeId = vehicleDetailModel.BodyTypeId;
                    vehicleDetail.Doors = vehicleDetailModel.Doors;
                    vehicleDetail.Engine = vehicleDetailModel.Engine;
                    vehicleDetail.Make = vehicleDetailModel.Make;
                    vehicleDetail.Model = vehicleDetailModel.Model;
                    vehicleDetail.VehicleId = vehicleDetailModel.VehicleId;
                    vehicleDetail.Wheels = vehicleDetailModel.Wheels;
                    }

                    return await db.SaveChangesAsync() >= 1;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
