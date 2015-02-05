using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.SinaWeiBo.Provider
{
    public interface ISinaWeiBoAuthenticationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user</param>
        /// <returns>A <see cref="Task"> representing the completed operation.</returns>
        Task Authenticated(SinaWeiBoAuthenticatedContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task ReturnEndPoint(SinaWeiBoReturnEndpointContext context);
    }
}
