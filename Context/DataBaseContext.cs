﻿using App.EFCore.Test.Mapping;
using App.EFCore.Test.Models.ManyToMany;
using App.EFCore.Test.Models.OneToMany;
using App.EFCore.Test.Models.OneToOne;
using Microsoft.EntityFrameworkCore;

namespace App.EFCore.Test.Context
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() { }

        // Relacionamento 1:1
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaEndereco> PessoaEnderecos { get; set; }

        // Relacionamento 1:N
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        // Relacionamento N:N
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroAutor> LivrosAutores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //1:1
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoMap());

            //1:N
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());

            //N:N
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new LivroAutorMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=server_name;Database=database_name;User ID=user_name;Password=password;");
        }

    }
}
