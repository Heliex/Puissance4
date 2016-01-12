namespace Puissance4Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=AccesBase")
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Boards> Boards { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<IdentityUsers> IdentityUsers { get; set; }
        public virtual DbSet<Stats> Stats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>()
                .HasMany(e => e.Boards)
                .WithOptional(e => e.Games)
                .HasForeignKey(e => e.IdGame_Id);

            modelBuilder.Entity<IdentityUsers>()
                .HasOptional(e => e.AspNetUsers)
                .WithRequired(e => e.IdentityUsers);

            modelBuilder.Entity<IdentityUsers>()
                .HasMany(e => e.Games)
                .WithOptional(e => e.IdentityUsers)
                .HasForeignKey(e => e.P1_Id);

            modelBuilder.Entity<IdentityUsers>()
                .HasMany(e => e.Games1)
                .WithOptional(e => e.IdentityUsers1)
                .HasForeignKey(e => e.P2_Id);

            modelBuilder.Entity<IdentityUsers>()
                .HasMany(e => e.Stats)
                .WithOptional(e => e.IdentityUsers)
                .HasForeignKey(e => e.Plose_Id);

            modelBuilder.Entity<IdentityUsers>()
                .HasMany(e => e.Stats1)
                .WithOptional(e => e.IdentityUsers1)
                .HasForeignKey(e => e.Pwin_Id);
        }
    }
}
