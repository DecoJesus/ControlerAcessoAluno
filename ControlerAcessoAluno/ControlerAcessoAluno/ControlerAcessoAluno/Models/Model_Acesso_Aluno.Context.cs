﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlerAcessoAluno.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CONTROLEACESSOEntities : DbContext
    {
        public CONTROLEACESSOEntities()
            : base("name=CONTROLEACESSOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_ACESSO> TB_ACESSO { get; set; }
        public virtual DbSet<TB_ALUNO> TB_ALUNO { get; set; }
        public virtual DbSet<TB_ALUNO_TURMA> TB_ALUNO_TURMA { get; set; }
        public virtual DbSet<TB_AUTORIZACAO> TB_AUTORIZACAO { get; set; }
        public virtual DbSet<TB_CARGO> TB_CARGO { get; set; }
        public virtual DbSet<TB_CURSO> TB_CURSO { get; set; }
        public virtual DbSet<TB_TURMA> TB_TURMA { get; set; }
        public virtual DbSet<TB_USUARIO> TB_USUARIO { get; set; }
    }
}
