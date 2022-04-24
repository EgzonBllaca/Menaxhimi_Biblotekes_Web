using Menaxhimi_Biblotekes_Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Menaxhimi_Biblotekes.Models
{
    public class Pjesemarresi
    {
        public int Id { get ; set; }
        public int RoliId { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Email { get; set; }
        public string Perdoruesi { get; set; }
        public string Fjalekalimi { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public virtual ICollection<PjesemarresiRoli> PjesemarresiRoli { get; set; }
        public virtual ICollection<Huazimi> Huazimi { get; set; }

    }
}
