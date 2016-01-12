namespace Puissance4Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUsers
    {
        public string Id { get; set; }

        [Required]
        public string Status { get; set; }

        public virtual IdentityUsers IdentityUsers { get; set; }
    }
}
