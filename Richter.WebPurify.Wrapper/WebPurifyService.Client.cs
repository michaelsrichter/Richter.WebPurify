// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyService.Client.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper
{
    #region Using

    using System.IO;
    using System.Net;
    using System.Xml.Linq;

    #endregion

    /// <summary>
    /// The web purify service.
    /// </summary>
    internal partial class WebPurifyService
    {
        #region Methods

        /// <summary>
        /// The get xml.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// XDocument object response from url REST request
        /// </returns>
        private static XDocument GetXml(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            string xml;
            using (var sr = new StreamReader(resp.GetResponseStream()))
            {
                xml = sr.ReadToEnd();
            }

            return XDocument.Parse(xml);
        }

        #endregion
    }
}