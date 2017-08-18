using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CloudKit
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TokenMiddleware : AuthorizationFilterAttribute
    {
        private const string _authorizedToken = "x-access-token";
        private const string _userAgent = "User-Agent";

        private UserAuthorizations objAuth = null;

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            string authorizedToken = string.Empty;
            string userAgent = string.Empty;

            try
            {
                if (filterContext.Request.Headers.Referrer != null)
                {
                    if (filterContext.Request.Headers.Referrer.AbsoluteUri != "http://localhost:8888/")
                    {
                        var headerToken = filterContext.Request.Headers.SingleOrDefault(x => x.Key == _authorizedToken);
                        if (headerToken.Key != null)
                        {
                            authorizedToken = headerToken.Value.SingleOrDefault();
                            userAgent = Convert.ToString(filterContext.Request.Headers.UserAgent);
                            if (!IsAuthorize(authorizedToken, userAgent))
                            {
                                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                                return;
                            }
                        }
                        else
                        {
                            filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                            return;
                        }
                    }
                }
                else
                {
                    var headerToken = filterContext.Request.Headers.SingleOrDefault(x => x.Key == _authorizedToken);
                    if (headerToken.Key != null)
                    {
                        authorizedToken = headerToken.Value.SingleOrDefault();
                        userAgent = Convert.ToString(filterContext.Request.Headers.UserAgent);
                        if (!IsAuthorize(authorizedToken, userAgent))
                        {
                            filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                            return;
                        }
                    }
                    else
                    {
                        filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                        return;
                    }
                }

            }
            catch (Exception)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }

            base.OnAuthorization(filterContext);
        }

        private bool IsAuthorize(string authorizedToken, string userAgent)
        {
            objAuth = new UserAuthorizations();
            bool result = false;
            try
            {
                result = objAuth.ValidateToken(authorizedToken, userAgent);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}