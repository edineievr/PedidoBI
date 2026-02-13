namespace PedidosBI.Domain.Entities
{
    public class PedidoBI
    {
        public long IdPedido { get; set; }
        public string NomeCliente { get; set; }
        public List<PedidoItemBI> Itens { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalLiquido => CalcularTotalPedido();

        public PedidoBI()
        {
            NomeCliente = string.Empty;
            Itens = new List<PedidoItemBI>();
        }

        public void AdicionarItem(string nomeProduto, decimal quantidade, decimal precoUnitario)
        {
            var item = new PedidoItemBI(nomeProduto, quantidade, precoUnitario);

            Itens.Add(item);
        }

        public decimal CalcularTotalPedido()
        {
            return Itens.Sum(item => item.CalcularTotalItem());
        }


    }
}
