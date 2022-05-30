using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FishStore.ViewModels
{
    public class FishViewModel
    {
        [Display(Name = "Tên Cá")]
        public string Name { get; set; }

        [Display(Name = "Loại Cá")]
        public string Genre { get; set; }

        [Display(Name = "Giống Cá")]
        public string Gender { get; set; }

        [Display(Name = "Giá Tiền")]
        public decimal Price { get; set; }

        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
    }
}