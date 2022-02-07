namespace WebApplication1.Models
{
    public class Emploi
    {
        public int Id { get; set; }
        public string Jour { get; set; }
        public string Seance { get; set; }
        public string Salle { get; set; }
        public int EnseignantId { get; set; }
        /*public virtual Enseignant Enseignant { get; set; }*/
        public int ClasseId { get; set; }
        public int MatiereId { get; set; }
        /*public virtual Matiere Matiere { get; set; }*/



        //Récuperation des objets et jointures par id fait dans la partie front

    }
}
