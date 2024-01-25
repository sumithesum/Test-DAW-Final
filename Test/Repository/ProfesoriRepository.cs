using Test.Data;

using Test.Interface;
using Test.Model;

namespace Test.Repository
{
    public class ProfesoriRepository : ProfesoriInterface
    {


        private readonly DataContext _context;
        public ProfesoriRepository(DataContext context)
        {
            _context = context;
        }

        public bool AdaugaProf(Profesori prof)
        {

            _context.Add(prof);
            return Save();
        }

        public Profesori GetProf(int id)
        {
            return _context.Profesori.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<Profesori> GetProfesori()
        {
            return _context.Profesori.OrderBy(p => p.Id).ToList();
        }

        public bool ProfesorExists(int profID)
        {
            return _context.Profesori.Any(p => p.Id == profID);
        }

        public bool ProfUpdate(Profesori prof)
        {
            _context.Update(prof);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        
    }
}
