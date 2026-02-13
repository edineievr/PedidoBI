using PedidosBI.Domain.DemoData;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosBI.Domain.Contracts
{
    public interface IPedidoRepository
    {
        public void Insert(Pedido pedido);
        public void Delete(long id);
        public List<Pedido> GetAll();

        public List<Pedido> GetFaturadosNoPeriodo(DateTime inicio, DateTime fim);
    }
}
