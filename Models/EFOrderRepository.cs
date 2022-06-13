using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FishStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private FishDbContext context;
        public EFOrderRepository(FishDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Fish);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Fish));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
