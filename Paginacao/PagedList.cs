using projetoBDO.Entities;

namespace projetoBDO.Paginacao
{
    public class PagedList<T>
    {
        public int TotalItens { get; private set; }
        public int ItensPorPagina { get; private set; }
        public int PaginaAtual { get; private set; }

        public int TotalPaginas => (int)Math.Ceiling((double)TotalItens / ItensPorPagina);

        public List<T> Itens { get; private set; }
        public PagedList(List<T> itens, int totalItens, int itensPorPagina, int paginaAtual)
        {
            this.Itens = itens;
            this.TotalItens = totalItens;
            this.ItensPorPagina = itensPorPagina;
            this.PaginaAtual = paginaAtual;
        }
    

    //public PagedList<Spot> ListarPagina(int paginaAtual, int itensPorPagina)
    //    {
    //        //var clientes = contexto.Clientes;
    //        var totalClientes = clientes.Count();
    //        var clientesDaPagina = clientes.Skip((paginaAtual - 1) * itensPorPagina).Take(itensPorPagina).ToList();

    //        return new PagedList<Spot>(clientesDaPagina, totalClientes, itensPorPagina, paginaAtual);
    //    }

    }
}
