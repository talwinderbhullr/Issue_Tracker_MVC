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
    public class AssigneesController : Controller
    {
        private readonly Issue_Tracker_MVCDataContext _context;

        public AssigneesController(Issue_Tracker_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Assignees
        public async Task<IActionResult> Index()
        {
            return View(await (from assignee in _context.Assignee
                               select assignee
                               ).ToListAsync());
        }

        // GET: Assignees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.Assignee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignee == null)
            {
                return NotFound();
            }

            return View(assignee);
        }

        // GET: Assignees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email")] Assignee assignee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignee);
        }

        // GET: Assignees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.Assignee.FindAsync(id);
            if (assignee == null)
            {
                return NotFound();
            }
            return View(assignee);
        }

        // POST: Assignees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Assignee assignee)
        {
            if (id != assignee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssigneeExists(assignee.Id))
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
            return View(assignee);
        }

        // GET: Assignees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignee = await _context.Assignee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignee == null)
            {
                return NotFound();
            }

            return View(assignee);
        }

        // POST: Assignees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignee = await _context.Assignee.FindAsync(id);
            _context.Assignee.Remove(assignee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssigneeExists(int id)
        {
            return _context.Assignee.Any(e => e.Id == id);
        }
    }
}
