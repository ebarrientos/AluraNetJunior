using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Categoria> GetCategorias()
        {
            return dbSet
                .Include(categoria => categoria.Produtos)
                .ToList();
        }

        public async Task<Categoria> SaveCategoria(string nomeCategoria)
        {
            var categoria = await dbSet.SingleOrDefaultAsync(item => item.Nome == nomeCategoria);

            if(categoria == null)
            {
                dbSet.Add(categoria = new Categoria(nomeCategoria));
                await contexto.SaveChangesAsync();
            }

            return categoria;
        }
    }

}
