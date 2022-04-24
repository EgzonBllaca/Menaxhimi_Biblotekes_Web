﻿using System;
using System.Collections.Generic;

namespace Menaxhimi_Biblotekes_Web.Models
{
    public class Kategoria
    {
        public int KategoriaID { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastUpdatedByUserID { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public virtual ICollection<KategoriaLibri> KategoriaLibri { get; set; }

    }
}
