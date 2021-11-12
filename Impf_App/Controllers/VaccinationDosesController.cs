namespace Impf_App.Controllers
{
    public class VaccinationDosesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VaccinationDosesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: VaccinationDoses
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccinationDoses.ToListAsync());
        }

        //GET: VaccinationDoses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationDosis = await _context.VaccinationDoses
                .FirstOrDefaultAsync(m => m.P_Dosis_Id == id);
            if (vaccinationDosis == null)
            {
                return NotFound();
            }

            return View(vaccinationDosis);
        }

        //GET: VaccinationDoses/Create
        public IActionResult Create()
        {
            PopulateVaccineDropDown();
            PopulatePatientDropDown();
            PopulateDoctorDropDown();
            return View();
        }

        //POST: VaccinationDoses/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("P_Dosis_Id,F_VaccineP_VaccineId,F_PatientP_InsuranceNr,ProductionDate,VaccinationDate,Place,Doctor")] VaccinationDosis vaccinationDosis)
        {
            if (ModelState.IsValid)
            {
                vaccinationDosis.P_Dosis_Id = Guid.NewGuid();
                _context.Add(vaccinationDosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDoctorDropDown(vaccinationDosis.F_DoctorP_DoctorId);
            PopulateVaccineDropDown(vaccinationDosis.F_VaccineP_VaccineId);
            PopulatePatientDropDown(vaccinationDosis.F_PatientP_InsuranceNr);
            return View(vaccinationDosis);
        }

        //GET: VaccinationDoses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationDosis = await _context.VaccinationDoses.FindAsync(id);
            if (vaccinationDosis == null)
            {
                return NotFound();
            }
            PopulateDoctorDropDown(vaccinationDosis.F_DoctorP_DoctorId);
            PopulateVaccineDropDown(vaccinationDosis.F_VaccineP_VaccineId);
            PopulatePatientDropDown(vaccinationDosis.F_PatientP_InsuranceNr);
            return View(vaccinationDosis);
        }

        //POST: VaccinationDoses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("P_Dosis_Id,F_VaccineP_VaccineId,F_PatientP_InsuranceNr,ProductionDate,VaccinationDate,Place,Doctor")] VaccinationDosis vaccinationDosis)
        {
            if (id != vaccinationDosis.P_Dosis_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccinationDosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationDosisExists(vaccinationDosis.P_Dosis_Id))
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
            PopulateDoctorDropDown(vaccinationDosis.F_DoctorP_DoctorId);
            PopulateVaccineDropDown(vaccinationDosis.F_VaccineP_VaccineId);
            PopulatePatientDropDown(vaccinationDosis.F_PatientP_InsuranceNr);
            return View(vaccinationDosis);
        }

        //GET: VaccinationDoses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationDosis = await _context.VaccinationDoses
                .FirstOrDefaultAsync(m => m.P_Dosis_Id == id);
            if (vaccinationDosis == null)
            {
                return NotFound();
            }
            return View(vaccinationDosis);
        }

        //POST: VaccinationDoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vaccinationDosis = await _context.VaccinationDoses.FindAsync(id);
            _context.VaccinationDoses.Remove(vaccinationDosis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDoctorDropDown(object selectedDoctor = null)
        {
            var doctorQuery = from d in _context.Doctors
                              orderby d.LastName, d.FirstName
                              select d;
            ViewBag.F_Vaccine = new SelectList(doctorQuery.AsNoTracking(), "Id", "FullName", selectedDoctor);
        }

        private void PopulateVaccineDropDown(object selectedVaccine = null)
        {
            var vaccineQuery = from v in _context.Vaccines
                               orderby v.Description
                               select v;
            ViewBag.F_Vaccine = new SelectList(vaccineQuery.AsNoTracking(), "P_VaccineId", "Description", selectedVaccine);
        }

        private void PopulatePatientDropDown(object selectedPatient = null)
        {
            var patientQuery = from p in _context.Patients
                               orderby p.LastName, p.FirstName
                               select p;
            ViewBag.F_Patient = new SelectList(patientQuery.AsNoTracking(), "P_InsuranceNr", "FullName", selectedPatient);
        }
        private bool VaccinationDosisExists(Guid id)
        {
            return _context.VaccinationDoses.Any(e => e.P_Dosis_Id == id);
        }
    }
}
