#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AbsencesContext : DbContext
    {
        public AbsencesContext (DbContextOptions<AbsencesContext> options)
            : base(options)
        {
        }

        public DbSet<Classe> Classe { get; set; }

        public DbSet<Etudiant> Etudiant { get; set; }

        public DbSet<WebApplication1.Models.Emploi> Emploi { get; set; }

        public DbSet<WebApplication1.Models.Enseignant> Enseignant { get; set; }

        public DbSet<WebApplication1.Models.Matiere> Matiere { get; set; }

        public DbSet<WebApplication1.Models.Specialite> Specialite { get; set; }

        public DbSet<WebApplication1.Models.Absence> Absence { get; set; }

        public DbSet<WebApplication1.Models.User> User { get; set; }

    }
}
