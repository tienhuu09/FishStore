using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class EFFishStoreRepository : IFishStoreRepository
    {
        private FishDbContext context;
        public EFFishStoreRepository(FishDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Fish> Fishs => context.Fishs;
        public void CreateFish(Fish b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteFish(Fish b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
        public void SaveFish(Fish b)
        {
            context.SaveChanges();
        }
    }

}

