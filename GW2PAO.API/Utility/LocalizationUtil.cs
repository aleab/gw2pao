using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace GW2PAO.API.Util
{
    /// <summary>
    /// Collection of localization utility methods
    /// </summary>
    public static class LocalizationUtil
    {
        /// <summary>
        /// Check UI Culture
        /// </summary>
        /// <returns>Current UI Culture is supported by API</returns>
        public static bool IsSupportedCulture()
        {
            var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            var supported = new[] { "en", "es", "fr", "de" };
            if (!supported.Contains(lang))
                return false;
            return true;
        }

    }
}