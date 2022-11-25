using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCode_EntityFramework.Models;

namespace MyCode_EntityFramework.Controllers
{
    public class UsertblsController : Controller
    {
        private readonly DataUserContext _context;

        public UsertblsController(DataUserContext context)
        {
            _context = context;
        }

        // GET: Usertbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usertbls.ToListAsync());
        }

        // GET: Usertbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usertbls == null)
            {
                return NotFound();
            }

            var usertbl = await _context.Usertbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usertbl == null)
            {
                return NotFound();
            }

            return View(usertbl);
        }

        // GET: Usertbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usertbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,BirthDay,Address,Email,Age,Gender")] Usertbl usertbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usertbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usertbl);
        }

        // GET: Usertbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usertbls == null)
            {
                return NotFound();
            }

            var usertbl = await _context.Usertbls.FindAsync(id);
            if (usertbl == null)
            {
                return NotFound();
            }
            return View(usertbl);
        }

        // POST: Usertbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Usertbl usertbl)
        {
            if (id != usertbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usertbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsertblExists(usertbl.Id))
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
            return View(usertbl);
        }

        // GET: Usertbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usertbls == null)
            {
                return NotFound();
            }

            var usertbl = await _context.Usertbls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usertbl == null)
            {
                return NotFound();
            }

            return View(usertbl);
        }

        // POST: Usertbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usertbls == null)
            {
                return Problem("Entity set 'DataUserContext.Usertbls'  is null.");
            }
            var usertbl = await _context.Usertbls.FindAsync(id);
            if (usertbl != null)
            {
                _context.Usertbls.Remove(usertbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // login 
        public async Task<IActionResult> Login(string username, string password)
        {
            {
                var p = _context.Usertbls.ToList();
                var userDetail = p.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                HttpContext.Session.SetString("UserID", username);
                string s = HttpContext.Session.GetString("UserID");
                ViewData["uID"] = "username";
                if (userDetail ==null)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Index", "Usertbls");
                }

            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            return RedirectToAction("Index","Home");
        }

        private bool UsertblExists(int id)
        {
            return _context.Usertbls.Any(e => e.Id == id);
        }
    }
}
