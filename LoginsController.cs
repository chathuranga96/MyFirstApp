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
    public class LoginsController : Controller
    {
        public static bool islogedin=false;
        //  public static string UserName;
        private readonly LibraryContext _context;

        public LoginsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Login.ToListAsync());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .SingleOrDefaultAsync(m => m.ID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login);

        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login.SingleOrDefaultAsync(m => m.ID == id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(int id, [Bind("ID,UserName,Password")] Login login)
        {


            if (id != login.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var User = await _context.UserVm.SingleOrDefaultAsync(m => (m.UserName == login.UserName) && (m.Password == login.Password));

                    if (User == null)
                    {
                        ViewBag.ErrorMessage = "This user doesn't exists";
                        islogedin = false;
                        return View("Create");

                    }
                    else
                    {
                        islogedin = true;
                        //  UserName = login.UserName;
                        return RedirectToAction("Index",
                        "Home"
                        );

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Create",
                          "Logins"
                          );
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .SingleOrDefaultAsync(m => m.ID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.Login.SingleOrDefaultAsync(m => m.ID == id);
            _context.Login.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.ID == id);
        }
        public async Task<IActionResult> LogOut()
        {
            islogedin = false;
            return RedirectToAction("Create",
                     "Logins"
                     );
        }
    }
}
