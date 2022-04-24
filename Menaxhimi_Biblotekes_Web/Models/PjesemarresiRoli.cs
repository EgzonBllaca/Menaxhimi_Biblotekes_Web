using Menaxhimi_Biblotekes.Models;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class PjesemarresiRoli
    {
        public int Id { get; set; }
        public int PjesemarresiId { get; set; }
        public int RoliId { get; set; }
        public virtual Pjesemarresi Pjesemarresi { get; set; }
        public virtual Roli Roli { get; set; }

    }
}
