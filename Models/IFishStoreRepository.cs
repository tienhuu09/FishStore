using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public interface IFishStoreRepository
    {
        IQueryable<Fish> Fishs { get; }
        void SaveFish(Fish b);
        void CreateFish(Fish b);
        void DeleteFish(Fish b);
    }
}
