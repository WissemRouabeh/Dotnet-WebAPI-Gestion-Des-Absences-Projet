namespace WebApplication1.Models
{
    public class Absence
    {
        
        public int Id { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public Boolean Abs { get; set; }
        public int EmploiId { get; set; }
        public int EtudiantId { get; set; }
        public int ClasseId { get; set; }
        public int EnseignatId { get; set; }
        public int MatiereId { get; set; }

        //Récuperation des objets par id fait dans la partie front
    }
}
