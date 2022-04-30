using Menaxhimi_Biblotekes.Models;
using System.ComponentModel.DataAnnotations;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class AutoriLibri
    {
        [Key]
        public int Id { get; set; }
        public int LibriId { get; set; }
        public int AutoriId { get; set; }

        public virtual Autori Autori { get; set; }
        public virtual Libri Libri { get; set; }
    }
}
