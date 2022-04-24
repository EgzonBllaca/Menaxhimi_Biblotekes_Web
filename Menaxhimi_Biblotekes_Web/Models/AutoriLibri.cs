using Menaxhimi_Biblotekes.Models;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class AutoriLibri
    {
        public int Id { get; set; }
        public int LibriId { get; set; }
        public int AutoriId { get; set; }

        public virtual Autori Autori { get; set; }
        public virtual Libri Libri { get; set; }
    }
}
