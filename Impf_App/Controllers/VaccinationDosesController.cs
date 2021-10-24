using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Impf_App.Data;
using Impf_App.Models;

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
            return View();
        }

        //POST: VaccinationDoses/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("P_Dosis_Id,ProductionDate,VaccinationDate,Place,Doctor")] VaccinationDosis vaccinationDosis)
        {
            if (ModelState.IsValid)
            {
                vaccinationDosis.P_Dosis_Id = Guid.NewGuid();
                _context.Add(vaccinationDosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(vaccinationDosis);
        }

        //POST: VaccinationDoses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("P_Dosis_Id,ProductionDate,VaccinationDate,Place,Doctor")] VaccinationDosis vaccinationDosis)
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

        private bool VaccinationDosisExists(Guid id)
        {
            return _context.VaccinationDoses.Any(e => e.P_Dosis_Id == id);
        }
    }
}
