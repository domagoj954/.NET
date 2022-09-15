using System.Collections;
using CarShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShopAPI.Models;

public class ShopService : IShopService{
  public ShopService(CarShopAPIDbContext context) {
    Db = context;
  }

  public async Task<IEnumerable> All() {
    return await Db.Shop.ToListAsync();
  }

  public async Task<Shop?> Get(int? id) {
    return await Db.Shop.FirstOrDefaultAsync(m => m.Id == id);
  }

  public async Task<int> Insert(Shop? shop) {
    if (shop != null) {
      Db.Add(shop);
      return await Db.SaveChangesAsync();
    }
    return -1;
  }

  public async Task<bool> Update(Shop? shop) {
    if (shop != null) {
      try {
        Db.Update(shop);
        await Db.SaveChangesAsync();
        return true;
      } catch (DbUpdateConcurrencyException) {
        return false;
      }
    }
    return false;
  }

  public async Task<int> Delete(int id) {
    var shop = await Get(id);
    if (shop != null) {
      Db.Shop.Remove(shop);
      return await Db.SaveChangesAsync();
    }
    return 0;
  }

    public CarShopAPIDbContext Db { get; }
}
