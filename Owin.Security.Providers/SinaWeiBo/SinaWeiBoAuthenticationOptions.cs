using Microsoft.Owin.Security;
using Owin.Security.Providers.SinaWeiBo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.SinaWeiBo
{
    public class SinaWeiBoAuthenticationOptions : AuthenticationOptions
    {
        public SinaWeiBoAuthenticationOptions()
            : base(Constants.DefaultAuthenticationType)
        {
            Caption = "新浪微博";
            ReturnEndpointPath = "/signin-sinaWeibo";
            AuthenticationMode = AuthenticationMode.Passive;
            Scope = new List<string> { "email" };
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            RequireEmail = false;
        }

        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

        public TimeSpan BackchannelTimeout { get; set; }

        public WebRequestHandler BackchannelHttpHandler { get; set; }

        public ISinaWeiBoAuthenticationProvider Provider { get; set; }

        public ICertificateValidator BackchannelCertificateValidator { get; set; }

        public IList<string> Scope { get; private set; }

        public string ReturnEndpointPath { get; set; }

        public string SignInAsAuthenticationType { get; set; }

        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        public string AppId { get; set; }

        public string AppSecret { get; set; }

        /// <summary>
        /// Make sure you got the advanced api authroity to enable this Property, more information please visit:
        /// http://open.weibo.com/wiki/%E9%AB%98%E7%BA%A7%E6%8E%A5%E5%8F%A3%E7%94%B3%E8%AF%B7
        /// </summary>
        public bool RequireEmail { get; set; }

    }
}
