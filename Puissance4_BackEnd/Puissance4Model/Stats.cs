namespace Puissance4Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stats
    {
        public string Id { get; set; }

        public int Turn { get; set; }

        public DateTime Time { get; set; }

        public bool BNull { get; set; }

        [StringLength(128)]
        public string Plose_Id { get; set; }

        [StringLength(128)]
        public string Pwin_Id { get; set; }

        public virtual IdentityUsers IdentityUsers { get; set; }

        public virtual IdentityUsers IdentityUsers1 { get; set; }
    }
}
