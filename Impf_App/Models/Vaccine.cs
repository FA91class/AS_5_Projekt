using System;
using System.ComponentModel.DataAnnotations;

namespace Impf_App.Models
{
    public class Vaccine
    {
        [Key]
        public Guid P_VaccineId { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public string Dosis { get; set; }

        public DateTime DateOfApproval { get; set; }
    }
}
