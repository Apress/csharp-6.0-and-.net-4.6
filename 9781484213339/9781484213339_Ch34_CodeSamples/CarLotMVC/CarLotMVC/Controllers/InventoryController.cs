using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;

namespace CarLotMVC.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryRepo _repo = new InventoryRepo();

        // GET: Inventory
        public async Task<ActionResult> Index()
        {
            return View(await _repo.GetAllAsync());
            //return PartialView(await _repo.GetAllAsync());
        }

        // GET: Inventory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inventory = await _repo.GetOneAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Make,Color,PetName")] Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty,"An error occurred in the data.  Please check all values and try again.");
                return View(inventory);
            }
            try
            {
                await _repo.AddAsync(inventory);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
                return View(inventory);
            }
        }

        // GET: Inventory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await _repo.GetOneAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CarId,Make,Color,PetName,Timestamp")] Inventory inventory)
        {
            if (!ModelState.IsValid) { return View(inventory); }
            try
            {
                await _repo.SaveAsync(inventory);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save record. Another user updated the record.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to save record: {ex.Message}");
            }
            return View(inventory);
        }

        // GET: Inventory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await _repo.GetOneAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Delete/5
        // No longer need the [ActionName("Delete")] attribute
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include="CarId,Timestamp")]Inventory inventory)
        {
            try
            {
                await _repo.DeleteAsync(inventory);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Unable to delete record. Another user updated the record.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
            }
            return View(inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
