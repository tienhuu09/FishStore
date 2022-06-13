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
        public MyCartModel(IFishStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long id, string returnUrl)
        {
            Fish fish= repository.Fishs
            .FirstOrDefault(b => b.Id == id);
            myCart.AddItem(fish, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long id, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Fish.Id == id).Fish);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }

}
