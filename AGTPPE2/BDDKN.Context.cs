﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AGTPPE2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDDKNEntities : DbContext
    {
        public BDDKNEntities()
            : base("name=BDDKNEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CELLULE> CELLULE { get; set; }
        public virtual DbSet<MATERIEL> MATERIEL { get; set; }
        public virtual DbSet<PROFIL> PROFIL { get; set; }
        public virtual DbSet<STATUT> STATUT { get; set; }
        public virtual DbSet<TYPECONNEXION> TYPECONNEXION { get; set; }
        public virtual DbSet<NIVEAUURGENCETICKET> NIVEAUURGENCETICKET { get; set; }
        public virtual DbSet<TICKETS> TICKETS { get; set; }
        public virtual DbSet<UTILISATEUR> UTILISATEUR { get; set; }
    }
}
