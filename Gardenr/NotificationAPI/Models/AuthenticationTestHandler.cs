using System.Net.Http;
using System.Threading;
using System.Security.Principal;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using System;

namespace NotificationAPI.Models
{
    public class AuthenticationTestHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            

            return base.SendAsync(request, cancellationToken);
        }

      

        private Task<HttpResponseMessage> Unauthorized()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}