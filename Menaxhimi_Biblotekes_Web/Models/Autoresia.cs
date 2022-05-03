using Menaxhimi_Biblotekes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class Autoresia
    {
        public Libri Libri { get; set; }/*
        public ICollection<Autori> AutoretEZgjedhur { get; set; }*/
        public int[] AutoriIds { get; set; }
        public ICollection<SelectListItem> Autoret { get; set; }
        public int KategoriaId { get; set; }
        public ICollection<SelectListItem> Kategorite { get; set; }
    }
}
