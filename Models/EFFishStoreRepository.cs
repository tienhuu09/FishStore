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
    }
}

