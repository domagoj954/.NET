using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarShopAPI.Models;

public class CarService : ICarService{
  public CarService(CarShopAPIDbContext context) {
    Db = context;
  }

  public async Task<IEnumerable> All(int shopId) {
    return await Db.Car.Where(e => e.ShopId == shopId).ToListAsync();
  }

  public async Task<Car?> Get(int? id) {
    return await Db.Car.FirstOrDefaultAsync(m => m.Id == id);
  }

  public async Task<int> Insert(Car? car) {
    if (car != null) {
      Db.Add(car);
      return await Db.SaveChangesAsync();
    }
    return -1;
  }

  public async Task<bool> Update(Car? car) {
    if (car != null) {
      try {
        Db.Update(car);
        await Db.SaveChangesAsync();
        return true;
      } catch (DbUpdateConcurrencyException) {
        return false;
      }
    }
    return false;
  }

  public async Task<int> Delete(int id) {
    var car = await Get(id);
    if (car != null) {
      Db.Car.Remove(car);
      return await Db.SaveChangesAsync();
    }
    return 0;
  }

    public CarShopAPIDbContext Db { get; }

}

