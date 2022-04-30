using Menaxhimi_Biblotekes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class PjesemarresiRoli
    {
        [Key]
        public int Id { get; set; }
        public int PjesemarresiId { get; set; }
        public int RoliId { get; set; }
        public virtual Pjesemarresi Pjesemarresi { get; set; }
        public virtual Roli Roli { get; set; }
    }
}
