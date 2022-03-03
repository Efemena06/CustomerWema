using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers;

public abstract class BaseKeyHandler : DelegatingHandler
{
    protected readonly ILogger _logger;
    public BaseKeyHandler(ILogger logger)
    {
        _logger = logger;
    }

    protected Task<HttpResponseMessage> BaseSendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogWarning($"Request headers: {string.Join(';', request.Headers.Select(o => $"{o.Key}:{string.Join(',', o.Value)}"))}");
        return base.SendAsync(request, cancellationToken);
    }

    protected abstract Task<HttpResponseMessage> SendWithTokenAsync(HttpRequestMessage request, CancellationToken cancellationToken, bool refreshToken = false);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = null;
        response = await SendWithTokenAsync(request, cancellationToken);
        return response;
    }

}