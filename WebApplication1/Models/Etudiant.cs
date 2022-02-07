namespace WebApplication1.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Cin { get; set; }
        public int NumTel { get; set; }
        public string NumIns { get; set; }
        public int ClasseId { get; set; }
        public int UserId { get; set; }


        //Récuperation des objets par id fait dans la partie front
    }
}
