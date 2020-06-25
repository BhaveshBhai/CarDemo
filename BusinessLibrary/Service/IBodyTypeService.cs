using DataAccessLibrary.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Service
{
   public interface IBodyTypeService
    {
        Task<IEnumerable<BodyType>> GetBodyTypes();
    }
}
