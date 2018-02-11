using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmmasBlogg.Models;

namespace EmmasBlogg.Controllers
{
    public class KategorisController : Controller
    {
        private readonly InläggsContext _context;

        public KategorisController(InläggsContext context)
        {
            _context = context;
        }

        // GET: Kategoris
        public async Task<IActionResult> Indexs()
        {
            return View(await _context.Kategorier.ToListAsync());
        }

        public IActionResult Index()
        {
            List<Kategori> kategorilista = new List<Kategori>();

            //--Data från Databasen med EF--
            kategorilista = (from Kategori in _context.Kategorier
                             where Kategori.KategoriID <= 3
                             select Kategori).ToList();

            kategorilista.Insert(0, new Kategori { KategoriID = 0, Namn = "Välj" });

            //--assigning kategorilista till ViewBag.ListOfCategory--
            ViewBag.ListaMedKategorier = kategorilista;
            return View();
        }



        // GET: Kategoris/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var kategori = await _context.Kategorier
        //        .SingleOrDefaultAsync(m => m.KategoriID == id);
        //    if (kategori == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(kategori);
        //}

        // GET: Kategoris/Create
        public IActionResult Create()
        {
            ViewData["Kategori"] = new SelectList(_context.Kategorier, "KategoriID", "Namn");
            return View();
        }

        // POST: Kategoris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriID,Namn")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // GET: Kategoris/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var kategori = await _context.Kategorier.SingleOrDefaultAsync(m => m.KategoriID == id);
        //    if (kategori == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(kategori);
        //}

        // POST: Kategoris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("KategoriID,Namn")] Kategori kategori)
        //{
        //    if (id != kategori.KategoriID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(kategori);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!KategoriExists(kategori.KategoriID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(kategori);
        //}

        // GET: Kategoris/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var kategori = await _context.Kategorier
        //        .SingleOrDefaultAsync(m => m.KategoriID == id);
        //    if (kategori == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(kategori);
        //}

        // POST: Kategoris/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var kategori = await _context.Kategorier.SingleOrDefaultAsync(m => m.KategoriID == id);
        //    _context.Kategorier.Remove(kategori);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool KategoriExists(int id)
        {
            return _context.Kategorier.Any(e => e.KategoriID == id);
        }
    }
}
