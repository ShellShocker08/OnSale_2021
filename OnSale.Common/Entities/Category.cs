using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnSale.Common.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }       

        public string ImagePath { get; set; }

        [Display(Name = "Imagen")]
        public string ImageFullPath => String.IsNullOrEmpty(ImagePath)
            ? $"~/img/static/noimage.png"
            : $"{ImagePath}";
    }
}