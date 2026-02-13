using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosBI.Domain.DemoData
{
    public class PedidoItem
    {
        public long Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalLiquido => CalcularValorTotal();

        public PedidoItem(string nomeProduto, decimal quantidade, decimal precoUnitario)
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public decimal CalcularValorTotal()
        {
            return Quantidade * PrecoUnitario;
        }
    }
}
