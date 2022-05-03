using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Menaxhimi_Biblotekes_Web.Models;

namespace Menaxhimi_Biblotekes.Models
{
    public class Autori
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Autori duhet te kete emer")]
        public string Emri { get; set; }
        [Required (ErrorMessage = "Autori duhet te kete mbiemer")]
        public string Mbiemri { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public virtual ICollection<AutoriLibri> AutoriLibri { get; set; }
    }
}
