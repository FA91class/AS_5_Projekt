using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Impf_App.Server.Models
{
    public class Insurance
{
        public Guid P_InssuranceId { get; set; }

        public string Description { get; set; }

        public string AdrNmbr { get; set; }

        public int PLZ { get; set; }

        public string Town { get; set; }
    }
}
