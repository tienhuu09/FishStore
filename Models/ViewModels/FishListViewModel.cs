using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models.ViewModels
{
    public class FishListViewModel
    {
        public IEnumerable<Fish> Fishs{ get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}