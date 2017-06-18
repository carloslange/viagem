using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ControleViagem.Authentication;
using ControleViagem.Droid.Authentication;
using ControleViagem.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace ControleViagem.Droid.Authentication
{
	public class AuthenticateDroid : IAuthentication
	{
		public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, 
                                                        MobileServiceAuthenticationProvider provider, 
                                                        IDictionary<string, string> parameters = null)
		{
			try
			{
				var user = await client.LoginAsync(Forms.Context, provider);

				Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
				Settings.UserId = user?.UserId;

				return user;
			}
			catch (Exception)
			{
				//TODO: LogError
				return null;
			}
		}
	}
}