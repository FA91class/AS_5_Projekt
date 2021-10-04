using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Impf_App.Server.Models
{
    public class VaccinationDosis
{
        public Guid P_Dosis_Id { get; set; }

        public Vaccine F_Vaccine { get; set; }

        public Patient F_Patient { get; set; }

        public Insurance F_Insurance { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime VaccinationDate { get; set; }

        public string Place { get; set; }

        public string Doctor { get; set; }

    }
}
