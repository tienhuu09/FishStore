using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishStore.Models;
using FishStore.MyTagHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FishStore.Pages
{
    public class MyCartModel : PageModel
    {
        private IFishStoreRepository repository;
        public MyCartModel(IFishStoreRepository repo)
        {
            repository = repo;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
        }
        public IActionResult OnPost(long id, string returnUrl)
        {
            Fish fish = repository.Fishs
            .FirstOrDefault(b => b.Id == id);
            myCart = HttpContext.Session.GetJson<MyCart>("mycart") ?? new MyCart();
            myCart.AddItem(fish, 1);
            HttpContext.Session.SetJson("mycart", myCart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
