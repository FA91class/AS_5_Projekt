namespace Impf_App.Controllers;

public class PatientsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PatientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Patients
    public async Task<IActionResult> Index()
    {
        return View(await _context.Patients.ToListAsync());
    }

    // GET: Patients/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = await _context.Patients
            .FirstOrDefaultAsync(m => m.P_InsuranceNr == id);
        if (patient == null)
        {
            return NotFound();
        }

        return View(patient);
    }

    // GET: Patients/Create
    public IActionResult Create()
    {
        PopulateInsuranceDropDown();
        return View();
    }

    // POST: Patients/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("P_InsuranceNr,PF_InsuranceP_InssuranceId,Sex,FirstName,LastName,BirtHDate,AdrNmbr,PLZ,Town")] Patient patient)
    {
        if (ModelState.IsValid)
        {
            patient.P_InsuranceNr = Guid.NewGuid();
            _context.Add(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        PopulateInsuranceDropDown(patient.PF_InsuranceP_InssuranceId);
        return View(patient);
    }

    // GET: Patients/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }
        PopulateInsuranceDropDown(patient.PF_InsuranceP_InssuranceId);
        return View(patient);
    }

    // POST: Patients/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("P_InsuranceNr,PF_InsuranceP_InssuranceId,Sex,FirstName,LastName,BirtHDate,AdrNmbr,PLZ,Town")] Patient patient)
    {
        if (id != patient.P_InsuranceNr)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(patient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(patient.P_InsuranceNr))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        PopulateInsuranceDropDown(patient.PF_InsuranceP_InssuranceId);
        return View(patient);
    }

    // GET: Patients/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = await _context.Patients
            .FirstOrDefaultAsync(m => m.P_InsuranceNr == id);
        if (patient == null)
        {
            return NotFound();
        }

        return View(patient);
    }

    // POST: Patients/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private void PopulateInsuranceDropDown(object selectedInsurance = null)
    {
        var insuranceQuery = from d in _context.Insurances
                             orderby d.Description
                             select d;
        ViewBag.PF_Insurance = new SelectList(insuranceQuery.AsNoTracking(), "P_InssuranceId", "Description", selectedInsurance);
    }

    private bool PatientExists(Guid id)
    {
        return _context.Patients.Any(e => e.P_InsuranceNr == id);
    }
}
