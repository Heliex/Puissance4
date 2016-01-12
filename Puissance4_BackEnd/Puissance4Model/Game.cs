namespace Puissance4Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Game
    {
        public int ID { get; set; }

        public DateTimeOffset DStart { get; set; }

        public DateTimeOffset DEnd { get; set; }

        [StringLength(128)]
        public string P1_Id { get; set; }

        [StringLength(128)]
        public string P2_Id { get; set; }

        //Navigation double sens
        public virtual Board Board { get; set; }
    }
}
