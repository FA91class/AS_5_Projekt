using System;

namespace Impf_App.Shared.Models
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
