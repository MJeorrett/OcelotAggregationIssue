using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OcelotAggregation
{
    public class MyAggregator : IDefinedAggregator
    {
        private readonly ILogger<MyAggregator> _logger;

        public MyAggregator(ILogger<MyAggregator> logger)
        {
            _logger = logger;
        }

        public async Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            var tasks = await Task.WhenAll(responses.Select(response =>
            {
                _logger.LogDebug($"Status code {response.DownstreamResponse.StatusCode}.");

                return response.DownstreamResponse.Content.ReadAsStringAsync();
            }));

            var responseBodies = tasks.Where(result => result != null).ToList();

            return new DownstreamResponse(
                new StringContent(JsonConvert.SerializeObject(responseBodies)),
                HttpStatusCode.OK,
                new List<Header>(),
                "OK");
        }
    }
}
