using Menaxhimi_Biblotekes.Models;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class Mesazhet
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ju duhet te shkruani emrin tuaj")]
        public string Emri { get; set; }
        [Required(ErrorMessage = "Ju duhet te shkruani emailin tuaj")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(2000, ErrorMessage = "Limiti i mesazhit eshte 2000 karaktere")]
        public string Mesazhi { get; set; }
        public int PjesemarresiId { get; set; }
        public Pjesemarresi Pjesemarresi { get; set; }
    }
}
