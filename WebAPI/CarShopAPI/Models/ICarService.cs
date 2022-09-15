using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Models;

public interface ICarService
{

    Task<IEnumerable> All(int shopId);

    Task<Car?> Get(int? id);

    Task<int> Insert(Car? car);

    Task<bool> Update(Car? car);

    Task<int> Delete(int id);

}
