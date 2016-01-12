namespace Puissance4Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            Boards = new HashSet<Boards>();
        }

        public int Id { get; set; }

        public DateTimeOffset DStart { get; set; }

        public DateTimeOffset DEnd { get; set; }

        [StringLength(128)]
        public string P1_Id { get; set; }

        [StringLength(128)]
        public string P2_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boards> Boards { get; set; }

        public virtual IdentityUsers IdentityUsers { get; set; }

        public virtual IdentityUsers IdentityUsers1 { get; set; }
    }
}
