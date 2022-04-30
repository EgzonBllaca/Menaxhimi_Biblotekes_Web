using Menaxhimi_Biblotekes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class Libri
    {
        [Key]
        public int Id { get; set; }
        public int KategoriaId { get; set; }
        public string Titulli { get; set; }
        public string Image { get; set; }
        public string Pershkrimi { get; set; }
        public string ISBN { get; set; }
        public string ShtepiaBotuese { get; set; }
        public int VitiBotimit { get; set; }
        public int NrKopjeve { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public virtual ICollection<AutoriLibri> AutoriLibri { get; set; }
        public virtual ICollection<KategoriaLibri> KategoriaLibri { get; set; }
        public virtual ICollection<Huazimi> Huazimi { get; set; }


    }
}
