using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Puissance4_FrontEnd.Models
{
    public class Stats
    {
        [Key]
        public string Id { get; set; }

        public virtual IdentityUser Pwin { get; set; }

        public virtual IdentityUser Plose { get; set; }

        public int Turn { get; set; }

        public DateTime Time { get; set; }

        public bool BNull { get; set; }

    }
}