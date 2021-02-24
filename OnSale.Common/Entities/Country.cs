using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnSale.Common.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public ICollection<State> States { get; set; }

        [DisplayName("# Estados")]
        public int StatesNumber => States == null ? 0 : States.Count;

    }
}
