﻿using Menaxhimi_Biblotekes_Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes.Models
{
    public class Huazimi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int LibriId { get; set; }
        [Required]
        public int PjesemarresiId { get; set; }

        public DateTime DataHuazimit { get; set; }
        public DateTime AfatiKthimit { get; set; }
        public DateTime DataKthimit { get; set; }
        public string Verejtje { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public virtual Libri Libri  { get; set; }
        public virtual Pjesemarresi Pjesemarresi { get; set; }
    }
}
