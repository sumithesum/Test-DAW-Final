using System.ComponentModel.DataAnnotations;

namespace Test.Model
{
    public class Profesori
    {
       
        public int Id { get; set; }

        public string Tip { get; set; }


        public ICollection<Join> Join { get; set; }
    }
}
