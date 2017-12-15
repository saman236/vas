using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace VAS.Panel.Application
{
    public class ApplicationAuthentication : DelegatingHandler
    {
        private bool ValidateToken(string token)
        {
            return true;
        }

        private bool Authentication()
        {
            return true;
        }

        private void Authorization(IPrincipal principal)
        {
            // Decription JWT Token

            if (principal == null)
            {
                principal = new UserPrincipal(new UserIdentity("Saman", "test", true, new List<string>() { Role.Admin, Role.Employee }));
            }

            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Contains("Token"))
            {
                var token = request.Headers.GetValues("Token").FirstOrDefault();
                if (!ValidateToken(token))
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Content = new StringContent(Messages.INVALID_AUTHENTICATION)
                    };
                }
            }
            else
            {
                if (!Authentication())
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Forbidden,
                        Content = new StringContent(Messages.UN_AUTHENTICATED)
                    };
                }
            }

            Authorization(null);

            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}