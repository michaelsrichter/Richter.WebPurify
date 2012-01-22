// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWebPurifyService.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The IWebPurifyService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper.Interfaces
{
    #region Using

    using Richter.WebPurify.Wrapper.Responses;

    #endregion

    /// <summary>
    /// The IWebPurifyService interface.
    /// </summary>
    public interface IWebPurifyService
    {
        #region Public Methods and Operators

        /// <summary>
        /// Services a Check Request.
        /// </summary>
        /// <param name="url">
        /// The url to web purify's REST service.
        /// </param>
        /// <returns>
        /// WebPurifyCheckResponse object
        /// </returns>
        WebPurifyCheckResponse Check(string url);

        /// <summary>
        /// Services a GetList Request.
        /// </summary>
        /// <param name="url">
        /// The url to web purify's REST service.
        /// </param>
        /// <returns>
        /// WebPurifyGetListResponse object
        /// </returns>
        WebPurifyGetListResponse GetList(string url);

        /// <summary>
        /// Services a ManageList Request.
        /// </summary>
        /// <param name="url">
        /// The url to web purify's REST service.
        /// </param>
        /// <returns>
        /// WebPurifyManageListResponse object
        /// </returns>
        WebPurifyManageListResponse ManageList(string url);

        /// <summary>
        /// Services a Replace Request
        /// </summary>
        /// <param name="url">
        /// The url to web purify's REST service.
        /// </param>
        /// <returns>
        /// WebPurifyReplaceResponse object
        /// </returns>
        WebPurifyReplaceResponse Replace(string url);

        #endregion
    }
}