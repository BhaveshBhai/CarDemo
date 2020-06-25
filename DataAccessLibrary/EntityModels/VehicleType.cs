using System;
using System.Collections.Generic;

namespace DataAccessLibrary.EntityModels
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            BodyType = new HashSet<BodyType>();
            VehicleDetail = new HashSet<VehicleDetail>();
        }

        public int VehicleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BodyType> BodyType { get; set; }
        public virtual ICollection<VehicleDetail> VehicleDetail { get; set; }
    }
}
