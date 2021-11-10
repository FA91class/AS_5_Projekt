namespace Impf_App.Controllers;

public class InsurancesController : Controller
{
    private readonly ApplicationDbContext _context;

    public InsurancesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Insurances
    public async Task<IActionResult> Index()
    {
        return View(await _context.Insurances.ToListAsync());
    }

    // GET: Insurances/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insurance = await _context.Insurances
            .FirstOrDefaultAsync(m => m.P_InssuranceId == id);
        if (insurance == null)
        {
            return NotFound();
        }

        return View(insurance);
    }

    // GET: Insurances/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Insurances/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("P_InssuranceId,Description,AdrNmbr,PLZ,Town")] Insurance insurance)
    {
        if (ModelState.IsValid)
        {
            insurance.P_InssuranceId = Guid.NewGuid();
            _context.Add(insurance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(insurance);
    }

    // GET: Insurances/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insurance = await _context.Insurances.FindAsync(id);
        if (insurance == null)
        {
            return NotFound();
        }
        return View(insurance);
    }

    // POST: Insurances/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("P_InssuranceId,Description,AdrNmbr,PLZ,Town")] Insurance insurance)
    {
        if (id != insurance.P_InssuranceId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(insurance);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(insurance.P_InssuranceId))
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
        return View(insurance);
    }

    // GET: Insurances/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insurance = await _context.Insurances
            .FirstOrDefaultAsync(m => m.P_InssuranceId == id);
        if (insurance == null)
        {
            return NotFound();
        }

        return View(insurance);
    }

    // POST: Insurances/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var insurance = await _context.Insurances.FindAsync(id);
        _context.Insurances.Remove(insurance);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InsuranceExists(Guid id)
    {
        return _context.Insurances.Any(e => e.P_InssuranceId == id);
    }
}
