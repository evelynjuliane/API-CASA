using System;
using System.Collections.Generic;
using System.Text;
using CasaDeShow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CasaDeShow.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CasaShow> CasasShows { get; set; }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);

           
            //Change my AspNetUser table to User
            builder.Entity<IdentityUser> ().ToTable ("User");

            //Change my AspNetRoles to Role
            builder.Entity<IdentityRole> ().ToTable ("Role");

        }

    }
}