using System.Collections.Generic;
using System.Linq;
using MobileSample.Core.Enums;

namespace MobileSample.Core.Models
{
    public class User : BaseEntities
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public EConductorClass ConductorClass { get; set; }
        public string[] VehicleIds { get; set; }
        public List<Vehicle> Vehicles { get; set; }


        public override bool ValidatePropertiesRequired()
        {
            return !string.IsNullOrWhiteSpace(Id) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(CompanyId) &&
                   VehicleIds.Any();
        }
        
    }
}