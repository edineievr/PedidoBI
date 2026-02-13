using PedidosBI.Domain.Contracts;
using PedidosBI.Domain.Entities;

namespace PedidosBI.Infrastructure.Repositories
{
    public class PedidoBIRepository : IPedidoBIRepository
    {
        private readonly List<PedidoBI> _pedidosBI;

        public PedidoBIRepository()
        {
            _pedidosBI = new List<PedidoBI>();
        }

        public IReadOnlyCollection<PedidoBI> GetAll()
        {
            return _pedidosBI;
        }

        public void Insert(PedidoBI pedido)
        {
            _pedidosBI.Add(pedido);
        }

        public void Delete(long id)
        {
            var pedido = _pedidosBI.FirstOrDefault(p => p.IdPedido == id);

            if (pedido != null)
            {
                _pedidosBI.Remove(pedido);
            }
        }
    }
}
