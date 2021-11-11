namespace Impf_App.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DashboardController
    public ActionResult Index()
    {
        var dsb = new Dashboard();
        dsb = GetDayDashboard(dsb);
        dsb = GetWeekDashboard(dsb);
        return View(dsb);
    }

    public Dashboard GetDayDashboard(Dashboard dsb)
    {
        var patients = _context.VaccinationDoses.Where(
            p => p.VaccinationDate.Date < DateTime.Today.AddDays(8)
            && p.VaccinationDate.Date > DateTime.Today.AddDays(-1));

        dsb.DayList = patients.ToList<VaccinationDosis>();

        return dsb;
    }

    public Dashboard GetWeekDashboard(Dashboard dsb)
    {
        var patients = _context.VaccinationDoses.Where(
            p => p.VaccinationDate.Date == DateTime.Today.Date);

        dsb.WeekList = patients.ToList<VaccinationDosis>();

        return dsb;
    }

}
