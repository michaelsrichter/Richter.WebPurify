// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyService.cs" company="">
//   
// </copyright>
// <summary>
//   The web purify service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper
{
    #region Using

    using Richter.WebPurify.Wrapper.Interfaces;
    using Richter.WebPurify.Wrapper.Responses;

    #endregion

    /// <summary>
    /// The web purify service.
    /// </summary>
    internal partial class WebPurifyService : IWebPurifyService
    {
        #region Public Methods and Operators

        /// <summary>
        /// Check method (check, checkount, return)
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// WebPurifyCheckResponse object
        /// </returns>
        public WebPurifyCheckResponse Check(string url)
        {
            return WebPurifyCreateResponse.CreateWebPurifyCheckResponse(GetXml(url));
        }

        /// <summary>
        /// The get list.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// WebPurifyGetListResponse object 
        /// </returns>
        public WebPurifyGetListResponse GetList(string url)
        {
            return WebPurifyCreateResponse.CreateWebPurifyGetListResponse(GetXml(url));
        }

        /// <summary>
        /// The manage list.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// WebPurifyManageListResponse object
        /// </returns>
        public WebPurifyManageListResponse ManageList(string url)
        {
            return WebPurifyCreateResponse.CreateWebPurifyManageListResponse(GetXml(url));
        }

        /// <summary>
        /// The replace.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// WebPurifyReplaceResponse object
        /// </returns>
        public WebPurifyReplaceResponse Replace(string url)
        {
            return WebPurifyCreateResponse.CreateWebPurifyReplaceResponse(GetXml(url));
        }

        #endregion
    }
}