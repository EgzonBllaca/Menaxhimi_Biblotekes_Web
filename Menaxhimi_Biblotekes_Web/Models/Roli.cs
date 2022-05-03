using Menaxhimi_Biblotekes_Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes.Models
{
    public class Roli
    {
        [Key]
        public int Id { get; set; }
        public string Pershkrimi { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Pjesemarresi> Pjesemarresi { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }

    }
}
