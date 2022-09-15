#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarShopAPI.Models;

namespace CarShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService ss;
        private readonly ICarService cs;

        public ShopController(IShopService shopService, ICarService carService)
        {
            ss = shopService;
            cs = carService;
        }


        // GET: api/Shop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShop()
        {
            return Ok(await ss.All());
        }

        // GET: api/Shop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> GetShop(int id)
        {
            var shop = await ss.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        // GET: api/Shop/5/Car
        [HttpGet("{id}/Car")]
        public async Task<ActionResult<IEnumerable<Car>>> GetShopCar(int id)
        {
            var shop = await ss.Get(id);

            if (shop != null)
            {
                return Ok(await cs.All(id));
            }

            return NotFound();
        }

        // GET: api/Shop/5/Car/3
        [HttpGet("{shopId}/Car/{carId}")]
        public async Task<ActionResult<IEnumerable<Car>>> GetShopCar(int shopId, int carId)
        {
            var shop = await ss.Get(shopId);

            if (shop != null)
            {
                var car = await cs.Get(carId);
                if (car != null)
                {
                    return Ok(car);
                }
                return NotFound();
            }

            return NotFound();
        }



        // PUT: api/Shop/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop(int id, Shop shop)
        {
            if (id != shop.Id)
            {
                return BadRequest();
            }

            if (await ss.Update(shop))
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        // PUT: api/Shop/5/Car/3
        [HttpPut("{shopId}/Car/{carId}")]
        public async Task<IActionResult> PutShopCar(int shopId, int carId, Car car)
        {
            if (carId != car.Id)
            {
                return BadRequest();
            }

            var shop = await ss.Get(shopId);
            if (shop != null)
            {
                if (await cs.Update(car))
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return NotFound();
        }





        // POST: api/Shop
        [HttpPost]
        public async Task<ActionResult<Shop>> PostShop(Shop shop)
        {
            await ss.Insert(shop);

            return CreatedAtAction("GetShop", new { id = shop.Id }, shop);
        }

        // POST: api/Shop/5/Car
        [HttpPost("{id}/Car")]
        public async Task<ActionResult<Car>> PostShopCar(int id, Car car)
        {
            //if (id != car.ShopId) {
            //  return BadRequest();
            //}

            var shop = await ss.Get(id);
            if (shop != null)
            {
                await cs.Insert(car);
                return CreatedAtAction("GetShopCar", new { shopId = id, carId = car.Id }, car);
            }

            return NotFound();
        }

        // DELETE: api/Shop/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int? id)
        {
            if (id == null) return NotFound();

            Shop shop;
            if ((shop = await ss.Get(id)) != null)
            {
                await ss.Delete(shop.Id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Shop/5/Car/3
        [HttpDelete("{shopId}/Car/{carId}")]
        public async Task<IActionResult> DeleteShopCar(int shopId, int carId)
        {
            var shop = await ss.Get(shopId);
            if (shop != null)
            {
                await cs.Delete(carId);
                return NoContent();
            }

            return NotFound();
        }
    }
}

