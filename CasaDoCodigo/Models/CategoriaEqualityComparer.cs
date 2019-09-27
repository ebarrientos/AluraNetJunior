using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class CategoriaEqualityComparer : IEqualityComparer<Categoria>
    {
        public static CategoriaEqualityComparer Instancia = new CategoriaEqualityComparer();
        public bool Equals(Categoria categoriaA, Categoria categoriaB)
        {
            if (object.ReferenceEquals(categoriaA, categoriaB))
            {
                return true;
            }

            if (object.ReferenceEquals(categoriaA, null) || object.ReferenceEquals(categoriaB, null))
            {
                return false;
            }

            return categoriaA.Nome == categoriaB.Nome;
        }

        public int GetHashCode(Categoria categoria)
        {
            if (object.ReferenceEquals(categoria, null))
            {
                return 0;
            }

            int nomeHash = categoria.Nome == null ? 0 : categoria.Nome.GetHashCode();

            return nomeHash;
        }
    }
}
