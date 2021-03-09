using System.ComponentModel.DataAnnotations;

namespace OnSale.Common.Request
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
