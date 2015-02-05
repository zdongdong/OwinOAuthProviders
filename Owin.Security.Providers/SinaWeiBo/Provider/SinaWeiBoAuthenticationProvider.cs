using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.SinaWeiBo.Provider
{
    public class SinaWeiBoAuthenticationProvider : ISinaWeiBoAuthenticationProvider
    {
        public SinaWeiBoAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null);
            OnReturnEndpoint = context => Task.FromResult<object>(null);
        }

        public Func<SinaWeiBoAuthenticatedContext, Task> OnAuthenticated { get; set; }

        public Func<SinaWeiBoReturnEndpointContext, Task> OnReturnEndpoint { get; set; }


        public Task Authenticated(SinaWeiBoAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        public Task ReturnEndPoint(SinaWeiBoReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }
    }
}
