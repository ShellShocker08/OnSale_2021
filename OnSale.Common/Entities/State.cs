using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnSale.Common.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]        
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        [DisplayName("# Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

        [JsonIgnore]
        [NotMapped]
        public int IdCountry { get; set; }

    }
}
