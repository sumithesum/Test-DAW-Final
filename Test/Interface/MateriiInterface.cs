using Test.Model;

namespace Test.Interface
{
    public interface MateriiInterface
    {
        ICollection<Materii> GetMaterii();

        Materii GetMat(int id);

        bool Save();

        bool MateriiExists(int matID);

        bool AdaugaMaterie(Materii mat);

        public bool MaterieUpdate(Materii mat);
    }
}
