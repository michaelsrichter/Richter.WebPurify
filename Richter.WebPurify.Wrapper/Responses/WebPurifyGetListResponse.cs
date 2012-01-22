// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyGetListResponse.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify get list response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper.Responses
{
    /// <summary>
    /// The web purify get list response.
    /// </summary>
    public class WebPurifyGetListResponse : WebPurifyResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Words.
        /// </summary>
        public string[] Words { get; set; }

        #endregion
    }
}