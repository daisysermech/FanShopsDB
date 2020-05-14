using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanShopsDB.Models
{
    public class Assortment
    {

        public Assortment()
        {
            Shops = new List<Shop>();
            Products = new List<Product>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Поставщик")]
        public int ProducerId { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
