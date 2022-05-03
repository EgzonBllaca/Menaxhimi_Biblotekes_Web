using Menaxhimi_Biblotekes_Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Menaxhimi_Biblotekes.Models
{
    public class Pjesemarresi
    {
        [Key]
        public int Id { get ; set; }
        [Required(ErrorMessage = "Ju duhet te shkruani emrin tuaj")]

        public string Emri { get; set; }

        [Required(ErrorMessage = "Ju duhet te shkruani mbiemrin tuaj")]
        public string Mbiemri { get; set; }

        [Required(ErrorMessage = "Ju duhet te shkruani emailin tuaj")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ju duhet te shkruani emrin e perdoruesit")]
        public string Perdoruesi { get; set; }

        [Required(ErrorMessage = "Ju duhet te shkruani fjalekalimin tuaj")]
        [StringLength(100,MinimumLength = 8,ErrorMessage = "Fjalekalimi duhet te kete se paku 8 karaktere")]
        [DataType(DataType.Password)]
        public string Fjalekalimi { get; set; }


        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public int RoliId { get; set; }
        public Roli Roli { get; set; }
        public virtual ICollection<Huazimi> Huazimi { get; set; }

    }
}
