namespace Puissance4Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Boards
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTimeOffset Date { get; set; }

        public int? IdGame_Id { get; set; }

        public virtual Games Games { get; set; }
    }
}
