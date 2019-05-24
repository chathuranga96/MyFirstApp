using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class UserVmsController : Controller
    {
        private readonly LibraryContext _context;

        public UserVmsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: UserVms
        public async Task<IActionResult> Index()
        {
            if (LoginsController.islogedin == true)
            {
                return View(await _context.UserVm.ToListAsync());
            }
            else
            {
                return RedirectToAction("Create",
                "Logins"
                 );
            }
            
        }

        // GET: UserVms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVm = await _context.UserVm
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userVm == null)
            {
                return NotFound();
            }

            return View(userVm);
        }

        // GET: UserVms/Create
        public IActionResult Create()
        {
            if (LoginsController.islogedin == true)
            {
                return View();
            }
            else
            {
              return RedirectToAction("Create",
              "Logins"
              );
            }
            
            
        }

        // POST: UserVms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password,FirstName,LastName,Address,Contact,Gender")] UserVm userVm)
        {
           
           if (LoginsController.islogedin == true)
            {
                if (ModelState.IsValid)
                {

                    var user1 = await _context.UserVm
                        .SingleOrDefaultAsync(m => m.UserName == userVm.UserName);
                    if (user1 == null)
                    {
                        _context.Add(userVm);
                        await _context.SaveChangesAsync();


                    }

                }
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return RedirectToAction("Create",
                "Logins"
                 );
            }
            
        }

        // GET: UserVms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVm = await _context.UserVm.SingleOrDefaultAsync(m => m.ID == id);
            if (userVm == null)
            {
                return NotFound();
            }
            return View(userVm);
        }

        // POST: UserVms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password,FirstName,LastName,Address,Contact,Gender")] UserVm userVm)
        {
            if (id != userVm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userVm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserVmExists(userVm.ID))
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
            return View(userVm);
        }

        // GET: UserVms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVm = await _context.UserVm
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userVm == null)
            {
                return NotFound();
            }

            return View(userVm);
        }

        // POST: UserVms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userVm = await _context.UserVm.SingleOrDefaultAsync(m => m.ID == id);
            _context.UserVm.Remove(userVm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserVmExists(int id)
        {
            return _context.UserVm.Any(e => e.ID == id);
        }
    }
}
