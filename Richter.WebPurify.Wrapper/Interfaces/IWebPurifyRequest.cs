// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWebPurifyRequest.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The IWebPurifyRequest interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper.Interfaces
{
    #region Using

    using Richter.WebPurify.Wrapper.Responses;

    #endregion

    /// <summary>
    /// The IWebPurifyRequest interface.
    /// </summary>
    public interface IWebPurifyRequest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Check Request handles check, checkout, return methods.
        /// </summary>
        /// <param name="text">
        /// The text to check.
        /// </param>
        /// <param name="method">
        /// The method (check, checkout, return).
        /// </param>
        /// <param name="matchEmail">
        /// If true, email will be treated as profanity.
        /// </param>
        /// <param name="matchPhoneNumber">
        /// If true, phone numbers will be treated as profanity.
        /// </param>
        /// <param name="language">
        /// Choose one of the supported languages.
        /// </param>
        /// <returns>
        /// WebPurifyCheckResponse object
        /// </returns>
        WebPurifyCheckResponse Check(
            string text, 
            WebPurifyCheckMethod method, 
            bool matchEmail = false, 
            bool matchPhoneNumber = false, 
            WebPurifySupportedLanguage language = WebPurifySupportedLanguage.English);

        /// <summary>
        /// GetList request handles getblacklist and getwhitelist
        /// </summary>
        /// <param name="type">
        /// The type (either black or white).
        /// </param>
        /// <returns>
        /// WebPurifyGetListResponse object
        /// </returns>
        WebPurifyGetListResponse GetList(WebPurifyListType type);

        /// <summary>
        /// ManageList request for addtowhitelist, addtoblacklist, removefromwhitelist, removefromblacklist
        /// </summary>
        /// <param name="method">
        /// Method for either Add or Remove.
        /// </param>
        /// <param name="type">
        /// Choose List Type (black or white).
        /// </param>
        /// <param name="word">
        /// The word you are adding or removing to the list
        /// </param>
        /// <returns>
        /// WebPurifyManageListResponse response.
        /// </returns>
        WebPurifyManageListResponse ManageList(WebPurifyListMethod method, WebPurifyListType type, string word);

        /// <summary>
        /// Replace request for replace method.
        /// </summary>
        /// <param name="text">
        /// the text to check.
        /// </param>
        /// <param name="replaceSymbol">
        /// The replace symbol.
        /// </param>
        /// <param name="wrapCData">
        /// if true, wraps returning text in CData tags.
        /// </param>
        /// <param name="matchEmail">
        /// if true, treats email as profanity
        /// </param>
        /// <param name="matchPhoneNumber">
        /// if ture, treats phone numbers as profanity.
        /// </param>
        /// <param name="language">
        /// Choose one of the supported languages
        /// </param>
        /// <returns>
        /// WebPurifyReplaceResponse object
        /// </returns>
        WebPurifyReplaceResponse Replace(
            string text, 
            char replaceSymbol, 
            bool wrapCData = false, 
            bool matchEmail = false, 
            bool matchPhoneNumber = false, 
            WebPurifySupportedLanguage language = WebPurifySupportedLanguage.English);

        #endregion
    }
}