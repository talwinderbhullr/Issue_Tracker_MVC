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
    public class IssuesController : Controller
    {
        private readonly Issue_Tracker_MVCDataContext _context;

        public IssuesController(Issue_Tracker_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            var issue_Tracker_MVCDataContext = _context.Issue.Include(i => i.Assignee).Include(i => i.IssueReporter);
            return View(await issue_Tracker_MVCDataContext.ToListAsync());
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .Include(i => i.Assignee)
                .Include(i => i.IssueReporter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            ViewData["AssigneeId"] = new SelectList(_context.Assignee, "Id", "Email");
            ViewData["IssueReporterId"] = new SelectList(_context.Set<IssueReporter>(), "Id", "Email");
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssigneeId,IssueReporterId,Content")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                issue.ReportedDate = DateTime.Now;
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssigneeId"] = new SelectList(_context.Assignee, "Id", "Email", issue.AssigneeId);
            ViewData["IssueReporterId"] = new SelectList(_context.Set<IssueReporter>(), "Id", "Email", issue.IssueReporterId);
           
            return View(issue);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            ViewData["AssigneeId"] = new SelectList(_context.Assignee, "Id", "Email", issue.AssigneeId);
            ViewData["IssueReporterId"] = new SelectList(_context.Set<IssueReporter>(), "Id", "Email", issue.IssueReporterId);
            return View(issue);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssigneeId,IssueReporterId, Content,ReportedDate")] Issue issue)
        {
            if (id != issue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
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
            ViewData["AssigneeId"] = new SelectList(_context.Assignee, "Id", "Id", issue.AssigneeId);
            ViewData["IssueReporterId"] = new SelectList(_context.Set<IssueReporter>(), "Id", "Id", issue.IssueReporterId);
            return View(issue);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .Include(i => i.Assignee)
                .Include(i => i.IssueReporter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.Issue.FindAsync(id);
            _context.Issue.Remove(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
            return _context.Issue.Any(e => e.Id == id);
        }
    }
}
