// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyUrlParameters.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify url parameters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Security.Policy;
using System.Web;

namespace Richter.WebPurify.Wrapper
{
    /// <summary>
    /// The web purify url parameters.
    /// </summary>
    internal static class WebPurifyUrlParameters
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add get method.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// adds the get method prefix to the url for a get list REST method
        /// </returns>
        public static string AddGetMethod(this string url, WebPurifyListType type)
        {
            return url + "?method=webpurify.live.get" + ListTypeText(type);
        }

        /// <summary>
        /// The add method.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// adds the correct check method to the REST url.
        /// </returns>
        public static string AddMethod(this string url, WebPurifyCheckMethod method)
        {
            return url + CheckMethodText(method);
        }

        /// <summary>
        /// The add method.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// add the web purify REST list method to the url.
        /// </returns>
        public static string AddMethod(this string url, WebPurifyListMethod method, WebPurifyListType type)
        {
            return url + ListMethodText(method) + ListTypeText(type);
        }

        /// <summary>
        /// The add param.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// adds a querystring parameter to the url
        /// </returns>
        public static string AddParam(this string url, WebPurifyArgument argument, string value)
        {
            return url + "&" + ParamText(argument) + "=" + value.Trim().ToEncodedUrl();
        }

        /// <summary>
        /// The add replace method.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// returns the replace url text for the replace method.
        /// </returns>
        public static string AddReplaceMethod(this string url)
        {
            return url + "?method=webpurify.live.replace";
        }

        /// <summary>
        /// The check method text.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// returns either check, checkcount or return.
        /// </returns>
        public static string CheckMethodText(WebPurifyCheckMethod method)
        {
            switch (method)
            {
                case WebPurifyCheckMethod.Check:
                    return "?method=webpurify.live.check";
                case WebPurifyCheckMethod.CheckCount:
                    return "?method=webpurify.live.checkcount";
                case WebPurifyCheckMethod.Return:
                default:
                    return "?method=webpurify.live.return";
            }
        }

        /// <summary>
        /// The language code.
        /// </summary>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <returns>
        /// Returns the appropriate 2 char code for supported language.
        /// </returns>
        public static string LanguageCode(WebPurifySupportedLanguage language)
        {
            switch (language)
            {
                case WebPurifySupportedLanguage.French:
                    return "fr";
                case WebPurifySupportedLanguage.Italian:
                    return "it";
                case WebPurifySupportedLanguage.Spanish:
                    return "es";
                case WebPurifySupportedLanguage.Arabic:
                    return "ar";
                default:
                    return "en";
            }
        }

        /// <summary>
        /// The list method text.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// Returns either Add or Remove
        /// </returns>
        public static string ListMethodText(WebPurifyListMethod method)
        {
            switch (method)
            {
                case WebPurifyListMethod.Add:
                    return "?method=webpurify.live.addto";
                case WebPurifyListMethod.Remove:
                default:
                    return "?method=webpurify.live.removefrom";
            }
        }

        /// <summary>
        /// The list type text.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// return Black or White
        /// </returns>
        public static string ListTypeText(WebPurifyListType type)
        {
            switch (type)
            {
                case WebPurifyListType.Black:
                    return "blacklist";
                case WebPurifyListType.White:
                default:
                    return "whitelist";
            }
        }

        /// <summary>
        /// The param text.
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <returns>
        /// The param text string.
        /// </returns>
        public static string ParamText(WebPurifyArgument argument)
        {
            switch (argument)
            {
                case WebPurifyArgument.ApiKey:
                    return "api_key";
                case WebPurifyArgument.CDataWrap:
                    return "cdata";
                case WebPurifyArgument.CheckEmail:
                    return "semail";
                case WebPurifyArgument.CheckPhone:
                    return "sphone";
                case WebPurifyArgument.Language:
                    return "lang";
                case WebPurifyArgument.ListWord:
                    return "word";
                case WebPurifyArgument.ReplaceSymbol:
                    return "replacesymbol";
                case WebPurifyArgument.Text:
                    return "text";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// The to url.
        /// </summary>
        /// <param name="b">
        /// this boolean
        /// </param>
        /// <returns>
        /// "1" or "0" depending if the boolean is true or false.
        /// </returns>
        public static string ToUrl(this bool b)
        {
            return b ? "1" : "0";
        }

        /// <summary>
        /// Enocodes the string for valid use as a url
        /// </summary>
        /// <param name="url">The url to encode</param>
        /// <returns></returns>
        public static string ToEncodedUrl(this string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        #endregion
    }
}