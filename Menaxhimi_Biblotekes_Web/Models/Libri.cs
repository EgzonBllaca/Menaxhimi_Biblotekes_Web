using Menaxhimi_Biblotekes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class Libri
    {
        public Libri()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Libri duhet te kete nje kategori")]
        public int KategoriaId { get; set; }
        
        [Required(ErrorMessage = "Libri duhet te kete nje titull")]
        public string Titulli { get; set; }/*
        public string Image { get; set; }*/

        public string Pershkrimi { get; set; }
        [Required(ErrorMessage ="Libri duhet ta kete nje ISBN")]
        [StringLength(13,MinimumLength = 13,ErrorMessage = "ISBN duhet te kete 13 shifra")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Libri duhet ta kete nje shtepi botuese")]
        [Display(Name = "Shtepia botuese")]
        public string ShtepiaBotuese { get; set; }
        [Required(ErrorMessage = "Ju duhet te shkruani vitin e botimit te librit")]
        [Display(Name = "Viti i botimit")]
        public int VitiBotimit { get; set; }

        [Required(ErrorMessage = "Libri duhet te kete sasine")]
        [Display (Name = "Numri i kopjeve")]      
        public int NrKopjeve { get; set; }


        public Kategoria Kategoria { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public virtual ICollection<AutoriLibri> AutoriLibri { get; set; }
        public virtual ICollection<Huazimi> Huazimi { get; set; }


    }
}
