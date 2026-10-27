using Windows.ApplicationModel.Resources;

namespace Fastedit
{
    /// <summary>
    /// Provides localized strings from Strings/&lt;lang&gt;/Resources.resw
    /// </summary>
    public static class Multilingual
    {
        private static readonly ResourceLoader loader = ResourceLoader.GetForViewIndependentUse();

        /// <summary>Returns the localized string for the given resource key.</summary>
        public static string L(string key)
        {
            var value = loader.GetString(key);
            return string.IsNullOrEmpty(value) ? key : value;
        }

        /// <summary>Returns a localized format string (e.g. "Welcome to Fastedit {0}!") filled with the arguments.</summary>
        public static string L(string key, params object[] args)
        {
            return string.Format(L(key), args);
        }
    }
}
