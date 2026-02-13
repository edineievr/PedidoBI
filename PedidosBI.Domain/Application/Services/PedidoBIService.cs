using PedidosBI.Domain.Contracts;
using PedidosBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosBI.Domain.Application.Services
{
    public class PedidoBIService
    {
        private readonly IPedidoBIRepository _pedidoBIRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoBIService(IPedidoBIRepository pedidoBIRepository, IPedidoRepository pedidoRepository)
        {
            _pedidoBIRepository = pedidoBIRepository;
            _pedidoRepository = pedidoRepository;
        }

        public void GerarPedidosBIDoDiaPorData()
        {
            var dataInicio = DateTime.UtcNow.Date.AddDays(-1);
            var dataFim = dataInicio.AddDays(1);

            var pedidosFaturados = _pedidoRepository.GetFaturadosNoPeriodo(dataInicio, dataFim);

            if (pedidosFaturados.Count == 0)
            {
                throw new Exception("Não há pedidos faturados no período.");//Verificar se não ter pedidos é estado válido ou se é um motivo de falha do job
            }

            foreach (var pedido in pedidosFaturados)
            {
                var pedidoBI = new PedidoBI();

                pedidoBI.IdPedido = pedido.Id;
                pedidoBI.NomeCliente = pedido.NomeCliente;
                pedidoBI.Data = pedido.DataFaturamento;

                foreach (var item in pedido.Itens)
                {
                    pedidoBI.AdicionarItem(item.NomeProduto, item.Quantidade, item.PrecoUnitario);
                }

                _pedidoBIRepository.Insert(pedidoBI);

            }
        }
    }
}
