// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyRequest.Client.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   TODO: Update summary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper
{
    #region Using

    using System.Configuration;

    #endregion

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class WebPurifyRequest
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "WebPurifyRequest" /> class.
        /// </summary>
        public WebPurifyRequest()
            : this(
                ConfigurationManager.AppSettings["WebPurifyUrl"], 
                ConfigurationManager.AppSettings["WebPurifyAppKey"], 
                new WebPurifyService())
        {
        }

        #endregion
    }
}