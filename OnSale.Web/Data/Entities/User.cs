using Microsoft.AspNetCore.Identity;
using OnSale.Common.Entities;
using OnSale.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnSale.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }

        [Display(Name = "Imagen")]
        public string ImageFullPath => ImagePath == String.Empty
            ? $"~/img/static/noimage.png"
            : $"{ImagePath}";

        [Display(Name = "Rol")]
        public UserType UserType { get; set; }

        public City City { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

    }
}
