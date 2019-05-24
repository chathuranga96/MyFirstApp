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
    public class ProfileManagementsController : Controller
    {
        private readonly LibraryContext _context;

        public ProfileManagementsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: ProfileManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfileManagement.ToListAsync());
        }

        // GET: ProfileManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileManagement = await _context.ProfileManagement
                .SingleOrDefaultAsync(m => m.ID == id);
            if (profileManagement == null)
            {
                return NotFound();
            }

            return View(profileManagement);
        }

        // GET: ProfileManagements/Create
        public IActionResult Create()
        {
            // ViewBag.UserName = LoginsController.UserName;
            return View();

        }

        // POST: ProfileManagements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password")] ProfileManagement profileManagement)
        {
            //profileManagement.UserName = LoginsController.UserName;
            if (ModelState.IsValid)
            {
                //profileManagement.ID = 3007;
                _context.Add(profileManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileManagement);
        }

        // GET: ProfileManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileManagement = await _context.ProfileManagement.SingleOrDefaultAsync(m => m.ID == id);
            if (profileManagement == null)
            {
                return NotFound();
            }
            return View(profileManagement);
        }

        // POST: ProfileManagements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password")] UserVm profileManagement)
        {
            profileManagement.ID = 1;
           // if (ModelState.IsValid)
           // {
                try
                {
                    UserVm userVm = new UserVm();
                    var user = await _context.UserVm.SingleOrDefaultAsync(m => m.UserName == profileManagement.UserName);

                    if (user == null)
                    {

                    }
                    else
                    {
                        userVm.ID = user.ID;
                        userVm.Password = user.Password;
                        _context.Update(userVm);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileManagementExists(profileManagement.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
           // return View(profileManagement);
        }

        // GET: ProfileManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileManagement = await _context.ProfileManagement
                .SingleOrDefaultAsync(m => m.ID == id);
            if (profileManagement == null)
            {
                return NotFound();
            }

            return View(profileManagement);
        }

        // POST: ProfileManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileManagement = await _context.ProfileManagement.SingleOrDefaultAsync(m => m.ID == id);
            _context.ProfileManagement.Remove(profileManagement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileManagementExists(int id)
        {
            return _context.ProfileManagement.Any(e => e.ID == id);
        }
    }
}
