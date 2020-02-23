using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Issue_Tracker_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Issue_Tracker_MVC.Controllers
{
    [Authorize]
    public class IssueReportersController : Controller
    {
        private readonly Issue_Tracker_MVCDataContext _context;

        public IssueReportersController(Issue_Tracker_MVCDataContext context)
        {
            _context = context;
        }

        // GET: IssueReporters
        public async Task<IActionResult> Index()
        {
            return View(await (from reporters in _context.IssueReporter
                               select reporters 
                               ).ToListAsync());
        }

        // GET: IssueReporters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueReporter = await _context.IssueReporter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issueReporter == null)
            {
                return NotFound();
            }

            return View(issueReporter);
        }

        // GET: IssueReporters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IssueReporters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] IssueReporter issueReporter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issueReporter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issueReporter);
        }

        // GET: IssueReporters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueReporter = await _context.IssueReporter.FindAsync(id);
            if (issueReporter == null)
            {
                return NotFound();
            }
            return View(issueReporter);
        }

        // POST: IssueReporters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] IssueReporter issueReporter)
        {
            if (id != issueReporter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issueReporter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueReporterExists(issueReporter.Id))
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
            return View(issueReporter);
        }

        // GET: IssueReporters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issueReporter = await _context.IssueReporter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issueReporter == null)
            {
                return NotFound();
            }

            return View(issueReporter);
        }

        // POST: IssueReporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issueReporter = await _context.IssueReporter.FindAsync(id);
            _context.IssueReporter.Remove(issueReporter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueReporterExists(int id)
        {
            return _context.IssueReporter.Any(e => e.Id == id);
        }
    }
}
