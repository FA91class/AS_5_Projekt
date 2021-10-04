using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Impf_App.Server.Models
{
    public class Patient
{
        public Guid P_InsuranceNr { get; set; }

        public Insurance PF_Insurance { get; set; }

        public string Sex { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirtHDate { get; set; }

        public string AdrNmbr { get; set; }

        public int PLZ { get; set; }

        public string Town { get; set; }
    }
}
