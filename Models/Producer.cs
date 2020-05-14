using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanShopsDB.Models
{
    public class Producer
    {

        public Producer()
        {
            Assortments = new List<Assortment>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Имя поставщика")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Наценка")]
        public int Pricing { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Страна")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Assortment> Assortments { get; set; }
    }
}
