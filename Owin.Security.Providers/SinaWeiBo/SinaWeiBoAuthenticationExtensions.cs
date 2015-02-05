using System;

namespace Owin.Security.Providers.SinaWeiBo
{
    public static class SinaWeiBoAuthenticationExtensions
    {
        public static IAppBuilder UseSinaWeiBoAuthentication(this IAppBuilder app, SinaWeiBoAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use(typeof(SinaWeiBoAuthenticationMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseSinaWeiBoAuthentication(this IAppBuilder app, string appId, string appSecret)
        {
            return UseSinaWeiBoAuthentication(app, new SinaWeiBoAuthenticationOptions()
            {
                AppId = appId,
                AppSecret = appSecret,
                SignInAsAuthenticationType = Constants.DefaultAuthenticationType
            });
        }


    }
}
