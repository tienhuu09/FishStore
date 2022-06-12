using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishStore.Models;
using FishStore.Models.ViewModels;


namespace FishStore.Controllers
{
    public class FishController : Controller
    {
        private IFishStoreRepository repository;
        public int PageSize = 3;
        public FishController(IFishStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int Page = 1)
         => View(new FishListViewModel
         {
             Fishs = repository.Fishs
         .Where(p => genre == null || p.Genre == genre)
         .OrderBy(p => p.Id)
         .Skip((Page - 1) * PageSize)
         .Take(PageSize),
            PagingInfo = new PagingInfo
            {
            CurrentPage = Page,
            ItemsPerPage = PageSize,
            TotalItems = genre == null ?
         repository.Fishs.Count() :
         repository.Fishs.Where(e =>
         e.Genre == genre).Count()
             },
             CurrentGenre = genre
         });


    }
}
