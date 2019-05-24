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
    public class LoginUsersController : Controller
    {
        private readonly LibraryContext _context;

        public LoginUsersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: LoginUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginUsers.ToListAsync());
        }

        // GET: LoginUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginUsers = await _context.LoginUsers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (loginUsers == null)
            {
                return NotFound();
            }

            return View(loginUsers);
        }

        // GET: LoginUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password")] LoginUsers loginUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginUsers);
        }

        // GET: LoginUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginUsers = await _context.LoginUsers.SingleOrDefaultAsync(m => m.ID == id);
            if (loginUsers == null)
            {
                return NotFound();
            }
            return View(loginUsers);
        }

        // POST: LoginUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password")] LoginUsers loginUsers)
        {
            if (id != loginUsers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginUsersExists(loginUsers.ID))
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
            return View(loginUsers);
        }

        // GET: LoginUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginUsers = await _context.LoginUsers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (loginUsers == null)
            {
                return NotFound();
            }

            return View(loginUsers);
        }

        // POST: LoginUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginUsers = await _context.LoginUsers.SingleOrDefaultAsync(m => m.ID == id);
            _context.LoginUsers.Remove(loginUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginUsersExists(int id)
        {
            return _context.LoginUsers.Any(e => e.ID == id);
        }
    }
}
