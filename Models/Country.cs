using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FanShopsDB.Models
{
    public class Country
    {

        public Country()
        {
            Cities = new List<City>();
            Producers = new List<Producer>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Страна")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Стоимость внутренней транспортировки")]
        public int InnerTrans { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Display(Name = "Стоимость внешней транспортировки")]
        public int OutterTrans { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
