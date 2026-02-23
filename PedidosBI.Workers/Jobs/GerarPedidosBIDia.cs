using PedidosBI.Domain.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TickerQ.Utilities.Base;

namespace PedidosBI.Workers.Jobs
{
    public class GerarPedidosBIDia
    {
        private readonly PedidoBIService _service;

        public GerarPedidosBIDia(PedidoBIService service)
        {
            _service = service;
        }

        [TickerFunction("GerarPedidosBIDiaJob", cronExpression: "*/10 * * * * *")]
        public Task GerarPedidosBIDiaJob(TickerFunctionContext context, CancellationToken cancellationToken)
        {
            Console.WriteLine("Job iniciado às: " + DateTime.Now);

            _service.GerarPedidosBIDoDiaPorData();

            Console.WriteLine("Job finalizado às: " + DateTime.Now);

            Console.WriteLine("EXECUTOU: " + DateTime.UtcNow);

            return Task.CompletedTask;
        }
    }
}
