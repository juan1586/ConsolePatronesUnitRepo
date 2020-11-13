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
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Usuario")
                .Property(u => u.Id)
                .HasColumnName("IdUsuario");

            modelBuilder.Entity<Comment>()
                .ToTable("Comentario")
                .Property(c => c.Id)
                .HasColumnName("IdComentario");
            modelBuilder.Entity<Comment>()
              .Property(c => c.Description)
              .HasColumnName("Descripcion");

            modelBuilder.Entity<Post>()
                .ToTable("Publicacion")
                .Property(p => p.Id)
                .HasColumnName("IdPublicacion");
            modelBuilder.Entity<Post>()
                .Property(p => p.Description)
                .HasColumnName("Descripcion");
            modelBuilder.Entity<Post>()
               .Property(p => p.UserId)
               .HasColumnName("IdUsuario");





        }
    }
}
