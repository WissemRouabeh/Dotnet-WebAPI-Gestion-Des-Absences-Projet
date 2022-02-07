namespace WebApplication1.Models
{
    public class Enseignant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Cin { get; set; }
        public int NumTel { get; set; }
       public int UserId { get; set; }
        /*public virtual ICollection<Emploi> Emplois { get; set; }*/


        //Récuperation des objets par id fait dans la partie front
    }
}
