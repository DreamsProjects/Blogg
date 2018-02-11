using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmmasBlogg.Models;
using System;

namespace EmmasBlogg.Controllers
{
    public class InläggController : Controller
    {
        private readonly InläggsContext _context;
        private readonly Inlägg inl;
        public List<SelectListItem> KatList;

        // POST: Inlägg/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include:"Titel,Text,KategoriId")] Inlägg inlägg, Kategori vald) 
        {
            if (ModelState.IsValid)
            {
                ViewBag.vald = new SelectList(_context.Poster, "Titel" , "Text", "KategoriId");
                inlägg.Datum = DateTime.Now;
                _context.Add(inlägg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(); //inlägg
        }

        // GET: Inlägg/Create
        public IActionResult Create()
        {
           ViewData["Kategori"] = new SelectList(_context.Kategorier, "KategoriID", "Namn");
            return View();
        }


        public InläggController(InläggsContext context)
        {
            _context = context;
        }


        // GET: Inlägg
        public async Task<IActionResult> Index() //Sorteras på datum
        {
          var hej = _context.Poster.OrderBy(x => x.Datum).Include(x => x.Kategori);
          
            return View(await hej.ToListAsync());
        }


        // GET: Inlägg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var inlägg = _context.Poster.Include(x => x.Kategori).SingleOrDefault(m => m.InläggsID == id);
            if (id == null)
            {
                return NotFound();
            }

            if (inlägg == null)
            {
                return NotFound();
            }
            return View(inlägg);
        }


        // GET: Inlägg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //ViewBag.kategori = new SelectList(_context.Kategorier.AsEnumerable(), "KategoriID", "Namn"); 

            if (id == null)
            {
                return NotFound();
            }

            var inlägg = _context.Poster.Include(x => x.Kategori).SingleOrDefault(m => m.InläggsID == id);
            inlägg.Datum = DateTime.Now;

            if (inlägg == null)
            {
                return NotFound();
            }

            return View(inlägg);
        }


        public async Task<IActionResult> Search(string titel)
        {
            var text = from x in _context.Poster.Include(x => x.Kategori)
                       select x;

            if (!String.IsNullOrEmpty(titel))
            {
                text = text.Where(y => y.Titel.Contains(titel)).OrderByDescending(x => x.Datum);
            }

            if (String.IsNullOrEmpty(titel)) //Tar fram alla om inte något specifikt anges!
            {
                text = text.OrderBy(x => x.Datum);
            }

            return View(await text.ToListAsync());
        }


        public async Task<IActionResult> SearchC(string titel) // y.Kategori.Namn.Equals(titel)
        {
            var text = from x in _context.Poster.Include(x => x.Kategori)
                       select x;

            if (!String.IsNullOrEmpty(titel))
            {
                text = text.Where(y => y.Kategori.Namn.Equals(titel)).OrderByDescending(x => x.Datum);
            }

            if(String.IsNullOrEmpty(titel))
            {
                return NotFound();
            }
            return View(await text.ToListAsync());
        }


        // POST: Inlägg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InläggsID,Titel,Text,Datum, Kategori.KategoriNamn")] Inlägg inlägg)
        {
            if (id != inlägg.InläggsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inlägg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InläggExists(inlägg.InläggsID))
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
            return View(inlägg);
        }


        // GET: Inlägg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inlägg = await _context.Poster
                .SingleOrDefaultAsync(m => m.InläggsID == id);
            if (inlägg == null)
            {
                return NotFound();
            }

            return View(inlägg);
        }


        // POST: Inlägg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inlägg = await _context.Poster.SingleOrDefaultAsync(m => m.InläggsID == id);
            _context.Poster.Remove(inlägg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InläggExists(int id)
        {
            return _context.Poster.Any(e => e.InläggsID == id);
        }
    }
}
