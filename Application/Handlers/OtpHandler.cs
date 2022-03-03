using Domain.Record.Response.OTP;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers;

public class OtpHandler : BaseKeyHandler
{
    public OtpHandler(ILogger<OtpHandler> logger) : base(logger)
    {
    }

    protected override async Task<HttpResponseMessage> SendWithTokenAsync(HttpRequestMessage request, CancellationToken cancellationToken, bool refreshToken = false)
    {
        var otpResponse = new OtpReponse
        {
            Status = true,
            OptString = "RANDON123"
        };

        return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(otpResponse)) };

    }
}
