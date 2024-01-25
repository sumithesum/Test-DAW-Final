
using Test.Model;

namespace Test.Interface
{
    public interface ProfesoriInterface
    {
        ICollection<Profesori> GetProfesori();

        Profesori GetProf(int id);

        bool Save();

        bool ProfesorExists(int profID);

        bool AdaugaProf(Profesori prof);

        public bool ProfUpdate(Profesori prof);
        
    }
}
