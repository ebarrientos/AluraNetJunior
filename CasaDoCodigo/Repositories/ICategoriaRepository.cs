using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        IList<Categoria> GetCategorias();

        Task<Categoria> SaveCategoria(string nomeCategoria);

    }
}