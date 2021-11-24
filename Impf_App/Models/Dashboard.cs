namespace Impf_App.Models;

[NotMapped]
public class Dashboard
{
    public List<VaccinationDosis> DayList { get; set; }

    public List<VaccinationDosis> WeekList { get; set; }
}
