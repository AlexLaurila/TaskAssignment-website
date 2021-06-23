using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WoM_Labb2.Data;
using WoM_Labb2.Models;

namespace WoM_Labb2.Controllers
{
    public class TasksController : Controller
    {
        private readonly DatabaseContext _context;

        public TasksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            IList<Assignments> assignmentList = new List<Assignments>();
            IList<Tasks> taskList = new List<Tasks>();

            var assignments = _context.Assignments
                .Include(a => a.Task)
                .Include(a => a.User);

            foreach (var item in assignments)
            {
                assignmentList.Add(item);
            }

            foreach(var item in _context.Tasks)
            {
                taskList.Add(item);
            }

            ViewData["Tasks"] = taskList;
            ViewData["User"] = assignmentList;

            return View();
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskID,BeginDateTime,DeadlineDateTime,Title,Requirements")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            IList<Assignments> assignmentList = new List<Assignments>();
            IList<Tasks> taskList = new List<Tasks>();

            var assignments = _context.Assignments
                .Include(a => a.Task)
                .Include(a => a.User);

            foreach (var item in assignments)
            {
                assignmentList.Add(item);
            }

            foreach (var item in _context.Tasks)
            {
                taskList.Add(item);
            }

            ViewData["Tasks"] = taskList;
            ViewData["User"] = assignmentList;

            return View("Index", tasks);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,BeginDateTime,DeadlineDateTime,Title,Requirements")] Tasks tasks)
        {
            if (id != tasks.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.TaskID))
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
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskID == id);
        }
    }
}
