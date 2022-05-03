using Menaxhimi_Biblotekes.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class KerkesatPerHuazim
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Duhet te zgjidhni nje liber")]
        public int LibriId { get; set; }

        [Required(ErrorMessage = "Duhet te zgjidhni nje perdorues")]
        public int PjesemarresiId { get; set; }
        [Display(Name = "Data e Kerkeses")]
        public DateTime DataKerkeses { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public virtual Libri Libri { get; set; }
        public virtual Pjesemarresi Pjesemarresi { get; set; }
    }
}
