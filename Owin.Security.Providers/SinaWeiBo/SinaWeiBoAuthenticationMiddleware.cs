using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.Infrastructure;
using Owin.Security.Providers.SinaWeiBo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.DataHandler;

namespace Owin.Security.Providers.SinaWeiBo
{
    class SinaWeiBoAuthenticationMiddleware : AuthenticationMiddleware<SinaWeiBoAuthenticationOptions>
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public SinaWeiBoAuthenticationMiddleware(
            OwinMiddleware next,
            IAppBuilder app,
            SinaWeiBoAuthenticationOptions options)
            : base(next,options)
        {
            _logger = app.CreateLogger<SinaWeiBoAuthenticationOptions>();

            if (Options.Provider == null)
            {
                Options.Provider = new SinaWeiBoAuthenticationProvider();
            }
            if (Options.StateDataFormat == null)
            {
                var dataProtecter = app.CreateDataProtector(
                    typeof(SinaWeiBoAuthenticationMiddleware).FullName,
                    Options.AuthenticationType, "v1");

                Options.StateDataFormat = new PropertiesDataFormat(dataProtecter);
            }

            _httpClient = new HttpClient(ResolveHttpMessageHandler(Options));
            _httpClient.Timeout = Options.BackchannelTimeout;
            _httpClient.MaxResponseContentBufferSize = 1024 * 1024 * 10; // 10 MB
        }

        protected override AuthenticationHandler<SinaWeiBoAuthenticationOptions> CreateHandler()
        {
            return new SinaWeiBoAuthenticationHandler(_httpClient, _logger);
        }

        private static HttpMessageHandler ResolveHttpMessageHandler(SinaWeiBoAuthenticationOptions options)
        {
            HttpMessageHandler handler = options.BackchannelHttpHandler ?? new WebRequestHandler();

            // If they provided a validator, apply it or fail.
            if (options.BackchannelCertificateValidator != null)
            {
                // Set the cert validate callback
                WebRequestHandler webRequestHandler = handler as WebRequestHandler;
                if (webRequestHandler == null)
                {
                    throw new InvalidOperationException("An ICertificateValidator cannot be specified at the same time as an HttpMessageHandler unless it is a WebRequestHandler.");
                }
                webRequestHandler.ServerCertificateValidationCallback = options.BackchannelCertificateValidator.Validate;
            }

            return handler;
        }
    }
}
