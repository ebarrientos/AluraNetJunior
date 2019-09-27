using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(IList<Produto> itens)
        {
            Itens = itens.Select(produto => produto.Categoria).Distinct(CategoriaEqualityComparer.Instancia).ToList();
        }

        public IList<Categoria> Itens { get; }
        public string Search { get; set; }
    }
}
