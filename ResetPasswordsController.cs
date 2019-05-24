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
    public class ResetPasswordsController : Controller
    {
        private readonly LibraryContext _context;

        public ResetPasswordsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: ResetPasswords
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResetPassword.ToListAsync());
        }

        // GET: ResetPasswords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resetPassword = await _context.ResetPassword
                .SingleOrDefaultAsync(m => m.ID == id);
            if (resetPassword == null)
            {
                return NotFound();
            }

            return View(resetPassword);
        }

        // GET: ResetPasswords/Create
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

        // POST: ResetPasswords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password,ConfirmPassword,Token")] ResetPassword resetPassword)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resetPassword);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resetPassword);
        }

        // GET: ResetPasswords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resetPassword = await _context.ResetPassword.SingleOrDefaultAsync(m => m.ID == id);
            if (resetPassword == null)
            {
                return NotFound();
            }
            return View(resetPassword);
        }

        // POST: ResetPasswords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password,ConfirmPassword,Token")] ResetPassword resetPassword)
        {
            if (id != resetPassword.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resetPassword);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResetPasswordExists(resetPassword.ID))
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
            return View(resetPassword);
        }

        // GET: ResetPasswords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resetPassword = await _context.ResetPassword
                .SingleOrDefaultAsync(m => m.ID == id);
            if (resetPassword == null)
            {
                return NotFound();
            }

            return View(resetPassword);
        }

        // POST: ResetPasswords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resetPassword = await _context.ResetPassword.SingleOrDefaultAsync(m => m.ID == id);
            _context.ResetPassword.Remove(resetPassword);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResetPasswordExists(int id)
        {
            return _context.ResetPassword.Any(e => e.ID == id);
        }
    }
}
