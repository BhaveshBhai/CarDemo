using System;
using System.Collections.Generic;

namespace DataAccessLibrary.EntityModels
{
    public partial class VehicleDetail
    {
        public int VehicleDetailsId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int? Doors { get; set; }
        public int? Wheels { get; set; }
        public int? VehicleId { get; set; }
        public int? BodyTypeId { get; set; }

        public virtual BodyType BodyType { get; set; }
        public virtual VehicleType Vehicle { get; set; }
    }
}
