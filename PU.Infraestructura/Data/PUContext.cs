using Microsoft.EntityFrameworkCore;
using PU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PU.Infraestructura.Data
{
    public class PUContext: DbContext   
    {
        public PUContext()
        {

        }

        public PUContext(DbContextOptions<PUContext> options)
          : base(options)
        { 

        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Usuario")
                .Property(u => u.Id)
                .HasColumnName("IdUsuario");

        }
    }
}
