using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;

namespace CarLotWebAPI.Controllers
{
    public class InventoryController : ApiController
    {
        private readonly InventoryRepo _repo = new InventoryRepo();

        public InventoryController()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Inventory, Inventory>()
                    .ForMember(x => x.Orders, opt => opt.Ignore());
                });
        }

        // GET: api/Inventory
        public IEnumerable<Inventory> GetInventory()
        {
            var inventories = _repo.GetAll();
            return Mapper.Map<List<Inventory>, List<Inventory>>(inventories);
        }

        // GET: api/Inventory/5
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = await _repo.GetOneAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Inventory, Inventory>(inventory));
        }

        // PUT: api/Inventory/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventory(int id, Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory.CarId)
            {
                return BadRequest();
            }
            try
            {
                await _repo.SaveAsync(inventory);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Inventory
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repo.AddAsync(inventory);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }
            return CreatedAtRoute("DefaultApi", new { id = inventory.CarId }, inventory);
        }

        // DELETE: api/Inventory/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteInventory(int id, Inventory inventory)
        {
            if (id != inventory.CarId)
            {
                return BadRequest();
            }
            try
            {
                await _repo.DeleteAsync(inventory);
            }
            catch (Exception ex)
            {
                //Production app should do more here
                throw;
            }
            return Ok();
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