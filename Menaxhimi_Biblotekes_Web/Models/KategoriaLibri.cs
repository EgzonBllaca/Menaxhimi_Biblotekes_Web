﻿namespace Menaxhimi_Biblotekes_Web.Models
{
    public class KategoriaLibri
    {
        public int Id { get; set; }
        public int LibriId { get; set; }
        public int KategoriaId { get; set; }

        public virtual Libri Libri { get; set; }
        public virtual Kategoria Kategoria { get; set; }
    }
}