using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Puissance4_FrontEnd.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public virtual IdentityUser P1 { get; set; }

        public virtual IdentityUser P2 { get; set; }

        public DateTimeOffset DStart { get; set; }

        public DateTimeOffset DEnd { get; set; }

    }
}