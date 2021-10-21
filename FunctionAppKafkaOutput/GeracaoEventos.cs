using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;

namespace FunctionAppKafkaOutput
{
    public static class GeracaoEventos
    {
        [FunctionName("GeracaoEventos")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log,
            [Kafka("BrokerKafka", "topic-azure-functions")] out string kafkaEventData)
        {
            string eventData = $"Evento gerado em: {DateTime.Now:HH:mm:ss}";
            log.LogInformation(eventData);
            kafkaEventData = eventData;
        }
    }
}
