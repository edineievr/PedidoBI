using System;
using System.Collections.Generic;
using System.Linq;
using PedidosBI.Domain.DemoData;
using PedidosBI.Infrastructure.Repositories;

namespace PedidosBI.Infrastructure
{
    public static class DataInitializer
    {
        public static void Seed(PedidoRepository pedidoRepo)
        {
            var hoje = DateTime.UtcNow.Date;
            var ontem = hoje.AddDays(-1);
            var anteOntem = hoje.AddDays(-2);
            var trintaDiasAtras = hoje.AddDays(-30);
            var sessentaDiasAtras = hoje.AddDays(-60);

            void AdicionarPedido(Pedido pedido, Action<Pedido>? statusHandler = null)
            {
                statusHandler?.Invoke(pedido);
                pedidoRepo.Insert(pedido);
            }

            AdicionarPedido(new Pedido
            {
                Id = 1,
                NomeCliente = "Maria Silva",
                DataCriacao = trintaDiasAtras,
                Itens = new List<PedidoItem>
                {
                    new("Camiseta Algodão", 2, 79.90m),
                    new("Calça Jeans Slim", 1, 189.90m),
                    new("Meia Esportiva", 3, 19.90m)
                }
            });

            AdicionarPedido(new Pedido
            {
                Id = 2,
                NomeCliente = "João Pereira",
                DataCriacao = sessentaDiasAtras,
                Itens = new List<PedidoItem>
                {
                    new("Fone Bluetooth", 1, 299.90m),
                    new("Cabo USB-C", 2, 39.90m),
                    new("Carregador Rápido", 1, 149.90m)
                }
            },
            p =>
            {
                p.Faturar();
                p.DataFaturamento = ontem.AddHours(10);
            });

            AdicionarPedido(new Pedido
            {
                Id = 3,
                NomeCliente = "Carla Souza",
                DataCriacao = ontem,
                Itens = new List<PedidoItem>
                {
                    new("Livro C# Avançado", 1, 129.90m),
                    new("Marca Página Magnético", 2, 14.90m),
                    new("Lâmpada de Leitura", 1, 69.90m)
                }
            });

            AdicionarPedido(new Pedido
            {
                Id = 4,
                NomeCliente = "Rafael Costa",
                DataCriacao = anteOntem,
                Itens = new List<PedidoItem>
                {
                    new("Notebook 14\" Ryzen 7", 1, 3999.00m),
                    new("Mouse Sem Fio", 2, 119.90m),
                    new("Headset USB", 1, 249.90m)
                }
            },
            p =>
            {
                p.Faturar();
                p.DataFaturamento = ontem.AddHours(15);
            });

            AdicionarPedido(new Pedido
            {
                Id = 5,
                NomeCliente = "Ana Lima",
                DataCriacao = ontem,
                Itens = new List<PedidoItem>
                {
                    new("Cafeteira Elétrica", 1, 349.90m),
                    new("Filtro de Água", 2, 39.90m),
                    new("Pó de Café Gourmet", 3, 32.90m)
                }
            },
            p =>
            {
                p.Cancelar();
                p.DataCancelamento = hoje.AddDays(1);
            });

            AdicionarPedido(new Pedido
            {
                Id = 6,
                NomeCliente = "Pedro Nunes",
                DataCriacao = ontem,
                Itens = new List<PedidoItem>
                {
                    new("Smartphone 128GB", 1, 2299.00m),
                    new("Película de Vidro", 1, 49.90m),
                    new("Capa Silicone", 1, 79.90m)
                }
            });

            AdicionarPedido(new Pedido
            {
                Id = 7,
                NomeCliente = "Luiza Rocha",
                DataCriacao = anteOntem,
                Itens = new List<PedidoItem>
                {
                    new("Kit Panelas Inox", 1, 499.00m),
                    new("Jogo de Talheres 24pçs", 1, 189.90m),
                    new("Tábua de Bambu", 1, 89.90m)
                }
            },
            p =>
            {
                p.Faturar();
                p.DataFaturamento = ontem.AddHours(20);
            });

            AdicionarPedido(new Pedido
            {
                Id = 8,
                NomeCliente = "Bruno Alves",
                DataCriacao = ontem,
                Itens = new List<PedidoItem>
                {
                    new("Tênis Running", 1, 399.90m),
                    new("Camiseta Dry Fit", 2, 89.90m),
                    new("Meia Cano Baixo", 3, 14.90m)
                }
            });

            AdicionarPedido(new Pedido
            {
                Id = 9,
                NomeCliente = "Marina Dias",
                DataCriacao = anteOntem,
                Itens = new List<PedidoItem>
                {
                    new("Monitor 27' IPS", 1, 1299.00m),
                    new("Suporte Articulado", 1, 189.90m),
                    new("Hub USB-C", 1, 159.90m)
                }
            },
            p =>
            {
                p.Faturar();
                p.DataFaturamento = ontem.AddHours(18);
            });

            AdicionarPedido(new Pedido
            {
                Id = 10,
                NomeCliente = "Felipe Mota",
                DataCriacao = hoje,
                Itens = new List<PedidoItem>
                {
                    new("Mochila de Couro", 1, 599.00m),
                    new("Carteira de Couro", 1, 199.00m),
                    new("Porta-Cartão RFID", 1, 89.90m)
                }
            },
            p =>
            {
                p.Cancelar();
                p.DataCancelamento = hoje.AddDays(2);
            });
        }
    }
}