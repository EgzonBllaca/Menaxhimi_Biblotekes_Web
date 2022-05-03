using Menaxhimi_Biblotekes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class RoliPjesemarresit
    {
        public Pjesemarresi Pjesemarresi { get; set; }
        public Roli Roli { get; set; }
        public int RoliId { get; set; }
        public ICollection<SelectListItem> Rolet { get; set; }

    }
}
