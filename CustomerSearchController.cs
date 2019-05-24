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
    public class CustomerSearchController : Controller
    {
        private readonly LibraryContext _context;

        public CustomerSearchController(LibraryContext context)
        {
            _context = context;
        }

        // GET: CustomerSearch
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserVm.ToListAsync());
        }

        // GET: CustomerSearch/Details/5
        public async Task<IActionResult> Details()
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

        public async Task<IActionResult> Search(string UserName)
        {
            if (UserName == null)
            {
                ViewBag.ErrorMessage = "Please Enter User Name";
                return View("Details");
            }

            var userVm = await _context.UserVm
                .SingleOrDefaultAsync(m => m.UserName == UserName);

            if(userVm==null)
            {
                ViewBag.ErrorMessage = "This user doesn't exists";
                return View("Details");


            }
            else
            {
                ViewBag.Name = userVm.FirstName;
                ViewBag.Address = userVm.Address;
                ViewBag.Contact = userVm.Contact;
                ViewBag.Gender = userVm.Gender;
                return View("Details");
            }


      
        }

        // GET: CustomerSearch/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: CustomerSearch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password,FirstName,LastName,Address,Contact,Gender")] UserVm userVm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userVm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userVm);
        }

        // GET: CustomerSearch/Edit/5
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

        // POST: CustomerSearch/Edit/5
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

        // GET: CustomerSearch/Delete/5
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

        // POST: CustomerSearch/Delete/5
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
