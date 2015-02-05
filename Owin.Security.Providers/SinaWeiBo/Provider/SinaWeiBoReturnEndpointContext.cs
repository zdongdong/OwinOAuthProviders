using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.SinaWeiBo.Provider
{
    /// <summary>
    /// Provides context information to middleware providers.
    /// </summary>
    public class SinaWeiBoReturnEndpointContext : ReturnEndpointContext
    {
        public SinaWeiBoReturnEndpointContext(IOwinContext context,AuthenticationTicket ticket):base(context,ticket)
        {
        }
    }
}
