using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FishStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(Fish fish, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.Fish.Id == fish.Id)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Fish = fish,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Fish fish) =>
        Lines.RemoveAll(l => l.Fish.Id == fish.Id);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Fish.Price * e.Quantity);
        public void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Fish Fish{ get; set; }
        public int Quantity { get; set; }
    }
}