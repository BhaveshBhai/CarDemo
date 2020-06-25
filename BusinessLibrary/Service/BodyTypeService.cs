using DataAccessLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Service
{
  public class BodyTypeService:IBodyTypeService
    {
        private readonly CarsaleDBContext db = new CarsaleDBContext();

        public async Task<IEnumerable<BodyType>> GetBodyTypes()
        {
            try
            {
                var bodyType = await db.BodyType.ToListAsync();
                return bodyType;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
