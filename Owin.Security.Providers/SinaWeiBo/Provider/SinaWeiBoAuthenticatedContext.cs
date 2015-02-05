using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Owin.Security.Providers.SinaWeiBo.Provider
{
    public class SinaWeiBoAuthenticatedContext : BaseContext
    {
        public SinaWeiBoAuthenticatedContext(IOwinContext context, JObject user, string email, string accessToken)
            :base(context)
        {
            IDictionary<string, JToken> userAsDictionary = user;

            User = user;
            AccessToken = accessToken;

            Id = User["id"].ToString();
            Name = PropertyValueIfExists("screen_name", userAsDictionary);

            Email = email;
        }

        public JObject User { get; private set; }
        public string AccessToken { get; private set; }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public ClaimsIdentity Identity { get; set; }
        public AuthenticationProperties Properties { get; set; }

        private static string PropertyValueIfExists(string property, IDictionary<string, JToken> dictionary)
        {
            return dictionary.ContainsKey(property) ? dictionary[property].ToString() : null;
        }
    }
}
