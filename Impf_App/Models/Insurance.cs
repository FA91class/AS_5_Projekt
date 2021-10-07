using System;
using System.ComponentModel.DataAnnotations;

namespace Impf_App.Models
{
    public class Insurance
    {
        [Key]
        public Guid P_InssuranceId { get; set; }

        public string Description { get; set; }

        public string AdrNmbr { get; set; }

        public int PLZ { get; set; }

        public string Town { get; set; }
    }
}
