namespace Puissance4Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stat
    {
        [Key]
        public int ID { get; set; }

        public int Turn { get; set; }

        public DateTime Time { get; set; }

        public bool BNull { get; set; }

        [StringLength(128)]
        public string Plose_Id { get; set; }

        [StringLength(128)]
        public string Pwin_Id { get; set; }

        public virtual User User1 { get; set; }

        public virtual User Users2 { get; set; }
    }
}
