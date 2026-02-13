using PedidosBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PedidosBI.Domain.DemoData
{
    public class Pedido
    {
        public long Id { get; set; }
        public string NomeCliente { get; set; }
        public decimal TotalLiquidoPedido => CalcularTotalPedido();
        public decimal TotalBrutoPedido { get; set; }
        public List<PedidoItem> Itens{ get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFaturamento { get; set; }
        public DateTime DataCancelamento { get; set; }


        public Pedido()
        {
            Itens = new List<PedidoItem>();
            NomeCliente = string.Empty;
            Status = Status.EmAberto;
            DataCriacao = DateTime.Now;
        }

        public void Faturar()
        {
            if (!(Status == Status.EmAberto))
            {
                throw new Exception("Pedido precisa estar aberto para ser faturado");
            }

            Status = Status.Faturado;
            DataFaturamento = DateTime.Now;
        }

        public void Cancelar()
        {            
            Status = Status.Cancelado;
            DataCancelamento = DateTime.Now;
        }

        private decimal CalcularTotalPedido()
        {
            return Itens.Sum(item => item.TotalLiquido);
        }

    }
}
