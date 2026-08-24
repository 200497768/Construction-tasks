using Construction_tasks.Data;
using Construction_tasks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construction_tasks.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Task.ToListAsync());
        }

        public async Task<IActionResult> InProgress()
        {
            List<Models.Task> tasks = await _context.Task.Where(m => !m.Completed).ToListAsync();

            return View(tasks);
        }

        public async Task<IActionResult> Completed()
        {
            List<Models.Task> tasks = await _context.Task.Where(m => m.Completed).ToListAsync();

            return View(tasks);
        }

        public async Task<IActionResult> AddExampleTasksAsync()
        {
            List<Models.Task> existingTasks = await _context.Task.ToListAsync();

            foreach (Models.Task task in existingTasks)
            {
                _context.Task.Remove(task);
                await _context.SaveChangesAsync();
            }

            List<Models.Task> exampleTasks = new List<Models.Task>();

            Models.Task task1 = new Models.Task();
            task1.Address = "401 Duckworth Street";
            task1.City = "Barrie";
            task1.Duration = "2 weeks";
            task1.Estimate = 3000;
            task1.Manager = "Manager";
            task1.Completed = true;
            exampleTasks.Add(task1);

            Models.Task task2 = new Models.Task();
            task2.Address = "402 Duckworth Street";
            task2.City = "Barrie";
            task2.Duration = "3 weeks";
            task2.Estimate = 4000;
            task2.Manager = "Manager";
            task2.Completed = true;
            exampleTasks.Add(task2);

            foreach (Models.Task task in exampleTasks)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
            }

            return View();
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,City,Duration,Estimate,Manager,Completed")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,City,Duration,Estimate,Manager,Completed")] Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
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
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Task.FindAsync(id);
            if (task != null)
            {
                _context.Task.Remove(task);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
