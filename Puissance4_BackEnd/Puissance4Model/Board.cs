namespace Puissance4Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Board
    {
        [Key, ForeignKey("Game")]
        public int Game_ID { get; set; }

        public string Content { get; set; }

        public DateTimeOffset Date { get; set; }

        public virtual Game Game { get; set; }
    }
}
