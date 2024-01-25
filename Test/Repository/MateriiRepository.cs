using Test.Data;
using Test.Interface;
using Test.Model;

namespace Test.Repository
{
    public class MateriiRepository : MateriiInterface
    {
        private readonly DataContext _context;
        public MateriiRepository(DataContext context)
        {
            _context = context;
        }

        public bool AdaugaMaterie(Materii mat)
        {
            _context.Add(mat);
            return Save();
        }

        public Materii GetMat(int id)
        {
            return _context.Materii.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Materii> GetMaterii()
        {
            return _context.Materii.OrderBy(p => p.Id).ToList();
        }

        public bool MaterieUpdate(Materii mat)
        {
            _context.Update(mat);
            return Save();
        }

        public bool MateriiExists(int matID)
        {
            return _context.Materii.Any(p => p.Id == matID);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
