using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoLotDAL.Models;
using Newtonsoft.Json;

namespace CarLotMVC.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:46024/api/Inventory");
            if (response.IsSuccessStatusCode)
            {
                var items = JsonConvert.DeserializeObject<List<Inventory>>(await response.Content.ReadAsStringAsync());
                return View(items);
            }
            return HttpNotFound();
        }

        // GET: Inventory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:46024/api/Inventory/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(await response.Content.ReadAsStringAsync());
                return View(inventory);
            }
            return HttpNotFound();
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
                ModelState.AddModelError(string.Empty, "An error occurred in the data.  Please check all values and try again.");
                return View(inventory);
            }
            try
            {
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("http://localhost:46024/api/Inventory", inventory);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unable to create record: {ex.Message}");
            }
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:46024/api/Inventory/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(await response.Content.ReadAsStringAsync());
                return View(inventory);
            }
            return new HttpNotFoundResult();
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CarId,Make,Color,PetName,Timestamp")] Inventory inventory)
        {
            if (!ModelState.IsValid) { return View(inventory); }
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync($"http://localhost:46024/api/Inventory/{inventory.CarId}", inventory);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
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
            var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:46024/api/Inventory/{id.Value}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(await response.Content.ReadAsStringAsync());
                return View(inventory);
            }
            return new HttpNotFoundResult();
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include = "CarId,Timestamp")]Inventory inventory)
        {
            try
            {
                var client = new HttpClient();

                HttpRequestMessage request = new HttpRequestMessage(
                    HttpMethod.Delete,
                    $"http://localhost:46024/api/Inventory/{inventory.CarId}")
                {
                    Content =
                        new StringContent(JsonConvert.SerializeObject(inventory), Encoding.UTF8, "application/json")
                };
                var response = await client.SendAsync(request);
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
            }
            base.Dispose(disposing);
        }
    }
}
