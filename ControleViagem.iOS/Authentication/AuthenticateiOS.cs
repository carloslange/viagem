using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleViagem.Authentication;
using ControleViagem.iOS.Authentication;
using Microsoft.WindowsAzure.MobileServices;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateiOS))]
namespace ControleViagem.iOS.Authentication
{

    public class AuthenticateiOS : IAuthentication
    {

       public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, 
                                                           MobileServiceAuthenticationProvider provider, 
                                                           IDictionary<string, string> parametros)
        {
           try
            {
                return await client.LoginAsync(UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController, provider);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
