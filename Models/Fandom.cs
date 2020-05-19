using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanShopsDB.Models
{
    public class Fandom
    {
        public Fandom()
        {
            Products = new List<Product>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Название фандома")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Короткое описание")]
        [MaxLength(1000, ErrorMessage = "Превышение допустимой длины.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Авторские права")]
        public string AR { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
