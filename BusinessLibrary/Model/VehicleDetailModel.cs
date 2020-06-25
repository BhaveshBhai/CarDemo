using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Model
{
   public class VehicleDetailModel
    {
        public int VehicleDetailsId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }
        public string VehicleType { get; set; }
        public string BodyType { get; set; }
        public int VehicleId { get; set; }
        public int BodyTypeId { get; set; }
    }
}
