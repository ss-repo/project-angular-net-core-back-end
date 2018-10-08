using System.Linq;
using APISistemaVeicularNet.Models;

namespace APISistemaVeicularNet.Repositorio
{
    public class VeiculosRepositorio : IVeiculosRepositorio
    {
        private readonly VeiculosContext _context;
        public VeiculosRepositorio(VeiculosContext ctx)
        {
            _context = ctx;
        }
        public void Add(Veiculos veiculos)
        {
            _context.Veiculos.Add(veiculos);
            _context.SaveChanges();
        }

        public Veiculos Find(long id)
        {
            return _context.Veiculos.FirstOrDefault(x =>x.id == id);
        }

        public System.Collections.Generic.IEnumerable<Veiculos> GetAll()
        {
            return _context.Veiculos.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.Veiculos.First(x =>x.id == id);
            _context.Veiculos.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Veiculos veiculos)
        {
            _context.Veiculos.Update(veiculos);
            _context.SaveChanges();
            
        }
    }
}