// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyResponse.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper.Responses
{
    /// <summary>
    /// The web purify response.
    /// </summary>
    public class WebPurifyResponse
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets ErrorCode.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        ///   Gets or sets ErrorMessage.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///   Gets or sets Format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        ///   Gets or sets Method.
        /// </summary>
        public string Method { get; set; }

        #endregion
    }
}