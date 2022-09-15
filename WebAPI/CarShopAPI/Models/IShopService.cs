using System.Collections;

namespace CarShopAPI.Models;

public interface IShopService {
  Task<IEnumerable> All();

  Task<Shop?> Get(int? id);

  Task<int> Insert(Shop? shop);

  Task<bool> Update(Shop? shop);

  Task<int> Delete(int id);
}
