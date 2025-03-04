using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace projetoBDO.Paginacao
{
    public class PaginatedList<T> : List<T>
    {
        public int PaginaAtual { get; private set; }
        public int TotalPages { get; private set; }

        // Construtor
        PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PaginaAtual = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        // Se PageIndex for maior que 1, temos uma página anterior
        public bool HasPreviousPage
        {
            get
            { return (PaginaAtual > 1); }

        }
        // se PageIndex for menor que TotalPages, temos uma próxima página
        public bool HasNextPage
        {
            get
            {
                return (PaginaAtual < TotalPages);
            }
        }

        // metodo para criar a lista paginada   
        // source é a lista de itens a serem paginados
        // pageIndex é o número da página
        // pageSize é o número de itens por página
        // source.Count() retorna o número total de itens
        // skip() pula os itens da página anterior
        // take() pega os itens da página atual
        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}



