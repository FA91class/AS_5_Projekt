using System;

namespace Impf_App.Shared.Models
{
    public class Vaccine
    {
        public Guid P_VaccineId { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public string Dosis { get; set; }

        public DateTime DateOfApproval { get; set; }
    }
}
