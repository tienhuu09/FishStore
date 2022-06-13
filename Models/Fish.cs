using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishStore.Models
{
    public class Fish
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên Cá")]
        [Display(Name = "Tên Cá")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Giống Cá")]
        [Display(Name = "Giống Cá")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        [Display(Name = "Giới Tính")]
        public string Gender { get; set; }

        [Range(1, 100000000)]
        [Required(ErrorMessage = "Không được để trống")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Display(Name = "Giá Tiền")]
        public decimal Price { get; set; }

        [Display(Name = "Thông tin ảnh")]   
        public string ProfilePicture { get; set; }
    }
}