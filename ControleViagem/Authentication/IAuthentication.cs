using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace ControleViagem.Authentication
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
                                          MobileServiceAuthenticationProvider provider,
                                           IDictionary<string, string> parametros = null);
    }
}
