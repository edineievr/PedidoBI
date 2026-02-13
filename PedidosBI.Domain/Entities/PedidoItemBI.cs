using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosBI.Domain.Entities
{
    public class PedidoItemBI
    {
        public long IdItem { get; protected set; }
        public string NomeProduto { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public decimal TotalItem => CalcularTotalItem();

        public PedidoItemBI(string nomeProduto, decimal quantidade, decimal precoUnitario)
        {
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public decimal CalcularTotalItem()
        {
            return Quantidade * PrecoUnitario;
        }
    }
}
