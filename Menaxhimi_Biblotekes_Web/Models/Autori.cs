using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Menaxhimi_Biblotekes_Web.Models;

namespace Menaxhimi_Biblotekes.Models
{
    public class Autori
    {
        public int Id { get; set; }
        public string Emri { get; set; }
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
