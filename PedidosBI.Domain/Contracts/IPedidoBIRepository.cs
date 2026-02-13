using PedidosBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosBI.Domain.Contracts
{
    public interface IPedidoBIRepository
    {
        public IReadOnlyCollection<PedidoBI> GetAll();
        public void Insert(PedidoBI pedido);
        public void Delete(long id);
    }
}
