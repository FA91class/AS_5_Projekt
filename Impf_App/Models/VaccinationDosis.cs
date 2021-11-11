namespace Impf_App.Models;

public class VaccinationDosis
{
    [Key]
    public Guid P_Dosis_Id { get; set; }

        public Guid F_VaccineP_VaccineId { get; set; }
        public Vaccine F_Vaccine { get; set; }

        public Guid F_PatientP_InsuranceNr { get; set; }
        public Patient F_Patient { get; set; }

        public DateTime ProductionDate { get; set; }

    public DateTime VaccinationDate { get; set; }

    public string Place { get; set; }

    public string Doctor { get; set; }
}
