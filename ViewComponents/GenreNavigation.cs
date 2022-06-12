using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishStore.Models;
namespace FishStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IFishStoreRepository repository;
        public GenreNavigation(IFishStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Fishs
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}