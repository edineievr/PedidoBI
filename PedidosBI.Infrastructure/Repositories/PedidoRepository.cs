using PedidosBI.Domain.Contracts;
using PedidosBI.Domain.DemoData;

namespace PedidosBI.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly List<Pedido> pedidos = new();

        public void Insert(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        public void Delete(long id)
        {
            var pedido = pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido != null)
            {
                pedidos.Remove(pedido);
            }
        }

        public List<Pedido> GetAll()
        {
            return pedidos;
        }

        public List<Pedido> GetFaturadosNoPeriodo(DateTime inicio, DateTime fim)
        {
            var faturados = pedidos.Where(p => p.Status == Status.Faturado && p.DataFaturamento >= inicio && p.DataFaturamento <= fim).ToList();
            Console.WriteLine($"[PedidoRepository] GetFaturadosNoPeriodo inicio={inicio:O} fim={fim:O} totalPedidos={pedidos.Count} faturadosEncontrados={faturados.Count}");
            return faturados;
        }
    }
}
