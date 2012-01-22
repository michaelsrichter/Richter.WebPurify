// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyRequest.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The WebPurifyRequest class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper
{
    #region Using

    using Richter.WebPurify.Wrapper.Interfaces;
    using Richter.WebPurify.Wrapper.Responses;

    #endregion

    /// <summary>
    /// The WebPurifyRequest class.
    /// </summary>
    public partial class WebPurifyRequest : IWebPurifyRequest
    {
        #region Constants and Fields

        /// <summary>
        ///   The key.
        /// </summary>
        private readonly string key;

        /// <summary>
        ///   The url.
        /// </summary>
        private readonly string url;

        /// <summary>
        ///   The IWebPurifyService service.
        /// </summary>
        private readonly IWebPurifyService webPurifyService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPurifyRequest"/> class.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="profanityFilterService">
        /// The profanity filter service.
        /// </param>
        public WebPurifyRequest(string url, string key, IWebPurifyService profanityFilterService)
        {
            this.url = url;
            this.key = key;
            this.webPurifyService = profanityFilterService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPurifyRequest"/> class.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        public WebPurifyRequest(string url, string key)
        {
            this.url = url;
            this.key = key;
            this.webPurifyService = new WebPurifyService();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Check Request handles check, checkout, return methods.
        /// </summary>
        /// <param name="text">
        /// The text to be checked.
        /// </param>
        /// <param name="method">
        /// Choose the check, checkout or return methods.
        /// </param>
        /// <param name="matchEmail">
        /// if true, email is treated as profanity.
        /// </param>
        /// <param name="matchPhoneNumber">
        /// if true, phone numbers are treated as profanity.
        /// </param>
        /// <param name="language">
        /// Choose a supported language.
        /// </param>
        /// <returns>
        /// WebPurifyCheckResponse object
        /// </returns>
        public WebPurifyCheckResponse Check(
            string text, 
            WebPurifyCheckMethod method, 
            bool matchEmail = false, 
            bool matchPhoneNumber = false, 
            WebPurifySupportedLanguage language = WebPurifySupportedLanguage.English)
        {
            return this.webPurifyService.Check(this.GetCheckUrl(text, method, matchEmail, matchPhoneNumber, language));
        }

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// WebPurifyGetListResponse object
        /// </returns>
        public WebPurifyGetListResponse GetList(WebPurifyListType type)
        {
            return this.webPurifyService.GetList(this.GetGetMethodUrl(type));
        }

        /// <summary>
        /// The manage list.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="word">
        /// The word.
        /// </param>
        /// <returns>
        /// WebPurifyManageListResponse object
        /// </returns>
        public WebPurifyManageListResponse ManageList(WebPurifyListMethod method, WebPurifyListType type, string word)
        {
            return this.webPurifyService.ManageList(this.GetManageListUrl(method, type, word));
        }

        /// <summary>
        /// The replace.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="replaceSymbol">
        /// The replace symbol.
        /// </param>
        /// <param name="wrapCData">
        /// The wrap c data.
        /// </param>
        /// <param name="matchEmail">
        /// The match email.
        /// </param>
        /// <param name="matchPhoneNumber">
        /// The match phone number.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <returns>
        /// WebPurifyReplaceResponse object
        /// </returns>
        public WebPurifyReplaceResponse Replace(
            string text, 
            char replaceSymbol, 
            bool wrapCData = false, 
            bool matchEmail = false, 
            bool matchPhoneNumber = false, 
            WebPurifySupportedLanguage language = WebPurifySupportedLanguage.English)
        {
            return
                this.webPurifyService.Replace(
                    this.GetReplaceUrl(text, replaceSymbol, wrapCData, matchEmail, matchPhoneNumber, language));
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get check url.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="matchEmail">
        /// The match email.
        /// </param>
        /// <param name="matchPhoneNumber">
        /// The match phone number.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <returns>
        /// returns URL for Web Purify REST service.
        /// </returns>
        internal string GetCheckUrl(
            string text, 
            WebPurifyCheckMethod method, 
            bool matchEmail, 
            bool matchPhoneNumber, 
            WebPurifySupportedLanguage language)
        {
            return
                this.url.AddMethod(method).AddParam(WebPurifyArgument.ApiKey, this.key).AddParam(
                    WebPurifyArgument.Text, text).AddParam(WebPurifyArgument.CheckEmail, matchEmail.ToUrl()).AddParam(
                        WebPurifyArgument.CheckPhone, matchPhoneNumber.ToUrl()).AddParam(
                            WebPurifyArgument.Language, WebPurifyUrlParameters.LanguageCode(language));
        }

        /// <summary>
        /// The get get method url.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// returns URL for Web Purify REST service.
        /// </returns>
        internal string GetGetMethodUrl(WebPurifyListType type)
        {
            return this.url.AddGetMethod(type).AddParam(WebPurifyArgument.ApiKey, this.key);
        }

        /// <summary>
        /// The get manage list url.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="word">
        /// The word.
        /// </param>
        /// <returns>
        /// returns URL for Web Purify REST service.
        /// </returns>
        internal string GetManageListUrl(WebPurifyListMethod method, WebPurifyListType type, string word)
        {
            return
                this.url.AddMethod(method, type).AddParam(WebPurifyArgument.ApiKey, this.key).AddParam(
                    WebPurifyArgument.ListWord, word);
        }

        /// <summary>
        /// The get replace url.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="replaceSymbol">
        /// The replace symbol.
        /// </param>
        /// <param name="wrapCData">
        /// The wrap c data.
        /// </param>
        /// <param name="matchEmail">
        /// The match email.
        /// </param>
        /// <param name="matchPhoneNumber">
        /// The match phone number.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        /// <returns>
        /// returns URL for Web Purify REST service.
        /// </returns>
        internal string GetReplaceUrl(
            string text, 
            char replaceSymbol, 
            bool wrapCData, 
            bool matchEmail, 
            bool matchPhoneNumber, 
            WebPurifySupportedLanguage language)
        {
            return
                this.url.AddReplaceMethod().AddParam(WebPurifyArgument.ApiKey, this.key).AddParam(
                    WebPurifyArgument.Text, text).AddParam(WebPurifyArgument.ReplaceSymbol, replaceSymbol.ToString()).
                    AddParam(WebPurifyArgument.CDataWrap, wrapCData.ToUrl()).AddParam(
                        WebPurifyArgument.CheckEmail, matchEmail.ToUrl()).AddParam(
                            WebPurifyArgument.CheckPhone, matchPhoneNumber.ToUrl()).AddParam(
                                WebPurifyArgument.Language, WebPurifyUrlParameters.LanguageCode(language));
        }

        #endregion
    }
}