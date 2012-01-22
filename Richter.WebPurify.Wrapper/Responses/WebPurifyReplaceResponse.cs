// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyReplaceResponse.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify replace response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper.Responses
{
    /// <summary>
    /// The web purify replace response.
    /// </summary>
    public class WebPurifyReplaceResponse : WebPurifyResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        public string Text { get; set; }

        #endregion
    }
}