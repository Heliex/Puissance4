using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Puissance4_FrontEnd.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTimeOffset Date { get; set; }

        public virtual Game IdGame { get; set; }

    }
}