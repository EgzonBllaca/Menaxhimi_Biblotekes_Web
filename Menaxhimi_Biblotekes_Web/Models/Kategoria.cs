using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class Kategoria
    {
        [Key]
        [Display(Name = "Kategoria")]
        public int KategoriaID { get; set; }
        [Required(ErrorMessage = "Duhet te shkruani emrin e kategoris")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public virtual ICollection<Libri> Librat { get; set; }

    }
}
