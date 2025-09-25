using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RpgApi.Controllers;

namespace RpgApi.Data
{
    public class DataContext : DbContext

    {
        //ctor
        public DataContext
        (DbContextOptions<DataContext> options) : base(options)
        {

        }
        //prop
        public DbSet<Personagem> TB_PERSONAGENS { get; set; }

        public DbSet<Arma> TB_ARMAS { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Personagem>().ToTable("TB_PERSONAGENS");

            modelBuilder.Entity<Personagem>().HasData
            (


            //Inserir as linhas " new Personagem(){Id=2,..."} da lista de personagem

            new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago }

            );


            
            modelBuilder.Entity<Arma>().ToTable("TB_ARMAS");

            modelBuilder.Entity<Arma>().HasData
            (

                new Arma() { Id = 1, Nome = "Facão", Dano = 30},
                new Arma() { Id = 2, Nome = "Scar", Dano = 120},
                new Arma() { Id = 3, Nome = "Mp40", Dano = 100},
                new Arma() { Id = 4, Nome = "Groza", Dano = 140},
                new Arma() { Id = 5, Nome = "Rambona", Dano = 135},
                new Arma() { Id = 6, Nome = "Ak47", Dano = 120},
                new Arma() { Id = 7, Nome = "Thompson", Dano = 110}



            );



        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.ConfigureWarnings(warnings => warnings
                    .Ignore(RelationalEventId.PendingModelChangesWarning));
            }


        



        

            protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            {
                configurationBuilder.Properties<String>().HaveColumnType("varchar").HaveMaxLength(200);
            }






        














    }
}