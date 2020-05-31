using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CheckCenter
{
    public class AdminSafeListMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AdminSafeListMiddleware> _logger;
        private readonly string _adminSafeList;

        public AdminSafeListMiddleware(RequestDelegate next, ILogger<AdminSafeListMiddleware> logger,
            string adminWhiteList)
        {
            _adminSafeList = adminWhiteList;
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var remoteIp = context.Connection.RemoteIpAddress;
            var pathUri = context.Request.Path.ToUriComponent();
            _logger.LogDebug($"Request from Remote IP address {remoteIp} on {pathUri}");

            var path = pathUri.Split("/");
            // Don't run this authentication on Angular endpoints, those are authenticated and redirected to /login
            // Don't run this authentication on login endpoints, so the user can still log in
            // e.g. /api/checks : [0]='', [1]='api', [2]='checks'
            if (path.Length >= 3 && path[1].Equals("api") && !path[2].Equals("session"))
            {
                
                if (context.Request.Method != "GET")
                {
                    var ip = _adminSafeList.Split(';');
                    var bytes = remoteIp.GetAddressBytes();
                    var badIp = ip.Select(IPAddress.Parse).All(testIp => !testIp.GetAddressBytes().SequenceEqual(bytes));

                    if (badIp)
                    {
                        _logger.LogInformation($"Forbidden Request from Remote IP address (validated by IP): {remoteIp}");
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return;
                    }
                }
                else
                {
                    context.Request.Cookies.TryGetValue("token", out var cookieToken);
                    if (cookieToken == null || cookieToken.Equals(""))
                    {
                        _logger.LogInformation($"Forbidden Request from Remote IP address (validated by token): {remoteIp}");
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        return;
                    }
                }
            }
            await _next.Invoke(context);
        }
    }
}