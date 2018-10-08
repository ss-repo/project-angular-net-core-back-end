using System.Collections.Generic;
using APISistemaVeicularNet.Models;

namespace APISistemaVeicularNet.Repositorio
{
    public interface IVeiculosRepositorio
    {
         void Add(Veiculos veiculos);
         IEnumerable<Veiculos> GetAll();
         Veiculos Find(long id);
         void Remove(long id);
         void Update(Veiculos veiculos);
    }
}