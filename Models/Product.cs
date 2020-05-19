using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanShopsDB.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Название продукта")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Себестоимость")]
        //[Range(0,Int32.MaxValue, ErrorMessage = "Себестоимость не может быть меньше 0.")]
        public int Price { get; set; }

        //[Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Фандом")]
        public int? FandomId { get; set; }

       // [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Ассортимент")]
        public int? AssortmentId { get; set; }

        public virtual Assortment Assortment { get; set; }
        public virtual Fandom Fandom { get; set; }
    }
}
