namespace Test.Model
{
    public class Join
    {
        public int ProfesorId { get; set; }
        public int MaterieId { get; set; }

        public Profesori Profesori { get; set; }

        public Materii Materie { get; set; }
    }
}
