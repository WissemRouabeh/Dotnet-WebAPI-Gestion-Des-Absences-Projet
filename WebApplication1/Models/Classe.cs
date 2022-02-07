using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Classe
    {
        public int Id { get; set; }
        public string Niveau { get; set; }
        public string Lib { get; set; }
        public string LibSpec { get; set; }
        public int SpecialiteId { get; set; }
        /*public virtual ICollection<Etudiant> Etudiants { get; set; }
        public virtual ICollection<Matiere> Matieres { get; set; }
        public virtual ICollection<Emploi> Emplois { get; set; }*/



        //Récuperation des objets par id fait dans la partie front
    }
}
