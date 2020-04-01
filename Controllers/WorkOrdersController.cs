using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleanTrackerV18.Models.CleanTracker;

namespace CleanTrackerV18.Controllers
{
    //private CleanTrackerEntites db = new CleanTrackerEntites();
    

    public class WorkOrdersController : Controller
    {
        private readonly CleanTrackerEntites _context;

        public WorkOrdersController(CleanTrackerEntites context)
        {
            _context = context;
        }

        // GET: WorkOrders
        public async Task<IActionResult> Index()
        {
            var cleanTrackerEntites = _context.WorkOrders.Include(w => w.Service).Include(w => w.Unit).Include(w => w.User);
            return View(await cleanTrackerEntites.ToListAsync());
        }

        // GET: WorkOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrders = await _context.WorkOrders
                .Include(w => w.Service)
                .Include(w => w.Unit)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrders == null)
            {
                return NotFound();
            }

            return View(workOrders);
        }

        // GET: WorkOrders/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceType");
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserFirstName");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderId,UserId,UnitId,ServiceId,WorkOrderNumber,WorkOrderName,WorkOrderServiceType,WorkOrderCompletionStatus,WorkOrderAssign,WorkOrderLastModified,WorkOrderLastModifiedBy,WorkOrderIsActive")] WorkOrders workOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceType", workOrders.ServiceId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", workOrders.UnitId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserFirstName", workOrders.UserId);
            return View(workOrders);
        }

        // GET: WorkOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var workOrders = await _context.WorkOrders.FindAsync(id);
            if (workOrders == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceType", workOrders.ServiceId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", workOrders.UnitId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserFirstName", workOrders.UserId);
            return View(workOrders);
            /*{
                public IActionResult Index()
                {

                }

            }*/
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderId,UserId,UnitId,ServiceId,WorkOrderNumber,WorkOrderName,WorkOrderServiceType,WorkOrderCompletionStatus,WorkOrderAssign,WorkOrderLastModified,WorkOrderLastModifiedBy,WorkOrderIsActive")] WorkOrders workOrders)
        {
            if (id != workOrders.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrdersExists(workOrders.WorkOrderId))
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
            ViewData["ServiceId"] = new SelectList(_context.Services, "ServiceId", "ServiceType", workOrders.ServiceId);
            ViewData["UnitId"] = new SelectList(_context.Units, "UnitId", "UnitName", workOrders.UnitId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserFirstName", workOrders.UserId);
            return View(workOrders);
        }

        // GET: WorkOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrders = await _context.WorkOrders
                .Include(w => w.Service)
                .Include(w => w.Unit)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrders == null)
            {
                return NotFound();
            }

            return View(workOrders);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrders = await _context.WorkOrders.FindAsync(id);
            _context.WorkOrders.Remove(workOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrdersExists(int id)
        {
            return _context.WorkOrders.Any(e => e.WorkOrderId == id);
        }
    }
}
