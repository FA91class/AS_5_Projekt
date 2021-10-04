using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Impf_App.Server.Models
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
