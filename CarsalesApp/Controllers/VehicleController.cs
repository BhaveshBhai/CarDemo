using Microsoft.AspNetCore.Mvc;
using BusinessLibrary.Model;
using BusinessLibrary.Service;
using System.Threading.Tasks;
using DataAccessLibrary.EntityModels;

namespace CarsalesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleDetailService _vehicleDetailService ;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IBodyTypeService _bodyTypeService;
        public VehicleController(IVehicleDetailService vehicleDetailService,IVehicleTypeService vehicleTypeService,IBodyTypeService bodyTypeService)
        {
            _vehicleDetailService = vehicleDetailService;
            _vehicleTypeService = vehicleTypeService;
            _bodyTypeService = bodyTypeService;
        }
        [HttpGet]
        [Route("VehicleTypes")]
        public async Task<IActionResult> VehicleTypes()
        {
            return Ok(await _vehicleDetailService.GetVehicleDetails());
        }
        [HttpGet]
        [Route("GetVevhicleTypes")]
        public async Task<IActionResult> GetVevhicleTypes()
        {
            return Ok(await _vehicleTypeService.GetVehicleTypes());
        }
        [HttpGet]
        [Route("GetBodyTypes")]
        public async Task<IActionResult> GetBodyTypes()
        {
            return Ok(await _bodyTypeService.GetBodyTypes());
        }
        
        [Route("SaveVehicleDetails")]

        public async Task<IActionResult> SaveVehicleDetails(VehicleDetail vehicleDetail)
        {
            return Ok(await _vehicleDetailService.SaveVehicleDetails(vehicleDetail));
        }
        //[HttpPost]
        //[Route("SaveContact")]
        //public async Task<IActionResult> SaveContact([FromBody] Vehi model)
        //{
        //    return Ok(await _contactService.SaveContact(model));
        //}

        //[HttpDelete]
        //[Route("DeleteContact/{contactId}")]
        //public async Task<IActionResult> DeleteContact(int contactId)
        //{
        //    return Ok(await _contactService.DeleteContact(contactId));
        //}
    }
}