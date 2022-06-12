using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public interface IFishStoreRepository
    {
        IQueryable<Fish> Fishs{ get; }
    }
}
