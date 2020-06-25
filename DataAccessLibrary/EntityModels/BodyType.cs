using System;
using System.Collections.Generic;

namespace DataAccessLibrary.EntityModels
{
    public partial class BodyType
    {
        public BodyType()
        {
            VehicleDetail = new HashSet<VehicleDetail>();
        }

        public int BodyId { get; set; }
        public string BodyName { get; set; }
        public int? VehicleId { get; set; }

        public virtual VehicleType Vehicle { get; set; }
        public virtual ICollection<VehicleDetail> VehicleDetail { get; set; }
    }
}
