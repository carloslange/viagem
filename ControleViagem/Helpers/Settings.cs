using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ControleViagem.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string userIdKey = "userId";
        private static readonly string userIdDefault = string.Empty;

        private const string authTokenKey = "authToken";
        private static readonly string authTokenDefault = string.Empty;


        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(userIdKey, userIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(userIdKey, value); }
        }

        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(authTokenKey, authTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(authTokenKey, value); }
        }

        public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(UserId);
    }
}