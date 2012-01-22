// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyCheckResponse.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify check response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper.Responses
{
    /// <summary>
    /// The web purify check response.
    /// </summary>
    public class WebPurifyCheckResponse : WebPurifyResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets Expletives.
        /// </summary>
        public string[] Expletives { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Found.
        /// </summary>
        public bool Found { get; set; }

        #endregion
    }
}