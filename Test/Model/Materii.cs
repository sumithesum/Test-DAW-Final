using System.ComponentModel.DataAnnotations;

namespace Test.Model
{
    public class Materii
    {
        public int Id { get; set; }

        public string Name { get; set; }
        

        public ICollection<Join> Join { get; set; }
    }
}
