namespace Impf_App.Models;

public class Patient
{
    [Key]
    public Guid P_InsuranceNr { get; set; }

        //[Key]
        public Guid PF_InsuranceP_InssuranceId { get; set; }
        public Insurance PF_Insurance { get; set; }

    public string Sex { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

        public string FullName { get { return LastName + ", " + FirstName; } }

        public DateTime BirtHDate { get; set; }

    public string AdrNmbr { get; set; }

    public int PLZ { get; set; }

    public string Town { get; set; }
}
