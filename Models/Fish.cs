using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishStore.Models
{
    public class Fish
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên Cá")]
        public string Name { get; set; }

        [Display(Name = "Loại Cá")]
        public string Genre { get; set; }

        [Display(Name = "Giống Cá")]
        public string Gender { get; set; }

        [Display(Name = "Giá Tiền")]
        public decimal Price { get; set; }

        [Display(Name = "Thông tin ảnh")]   
        public string ProfilePicture { get; set; }
    }
}