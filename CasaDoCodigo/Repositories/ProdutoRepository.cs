using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private ICategoriaRepository _categoriaRepository { get; }
        public ProdutoRepository(ApplicationContext contexto, ICategoriaRepository categoriaRepository) : base(contexto)
        {
            _categoriaRepository = categoriaRepository;
        }


        public async Task<IList<Produto>> GetProdutos()
        {
            return await dbSet
                .Include(produto => produto.Categoria)
                .ToListAsync();
        }


        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    var categoria = await _categoriaRepository.SaveCategoria(livro.Categoria);

                    dbSet.Add(new Produto(
                        livro.Codigo,
                        livro.Nome,
                        categoria,
                        livro.Preco));
                }
            }
            await contexto.SaveChangesAsync();
        }
        
        public async Task<IList<Produto>> GetProdutos(string searchNomeProdutoCategoria)
        {
            searchNomeProdutoCategoria = searchNomeProdutoCategoria?.ToUpper();

            if (string.IsNullOrWhiteSpace(searchNomeProdutoCategoria))
                return await GetProdutos();


            return await dbSet
                .Include(produto => produto.Categoria)
                .Where(produto =>
                    produto.Nome.ToUpper().Contains(searchNomeProdutoCategoria) ||
                    produto.Categoria.Nome.ToUpper().Contains(searchNomeProdutoCategoria))
                .ToListAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
