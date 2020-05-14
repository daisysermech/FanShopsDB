using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanShopsDB.Models
{
    public class City
    {
        public City()
        {
            Shops = new List<Shop>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Название города")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Страна")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
