// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyCreateResponse.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify create response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper
{
    #region Using

    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    using Richter.WebPurify.Wrapper.Responses;

    #endregion

    /// <summary>
    /// The web purify create response.
    /// </summary>
    internal static class WebPurifyCreateResponse
    {
        #region Public Methods and Operators

        /// <summary>
        /// Create Web Purify Check Response
        /// </summary>
        /// <param name="xml">
        /// The xml returned from the REST request to Web Purify.
        /// </param>
        /// <returns>
        /// WebPurifyCheckResponse object
        /// </returns>
        internal static WebPurifyCheckResponse CreateWebPurifyCheckResponse(XContainer xml)
        {
            var firstOrDefault = xml.Elements("rsp").FirstOrDefault();
            if (firstOrDefault != null && firstOrDefault.Attribute(XName.Get("stat")).Value == "fail")
            {
                return CreateWebPurifyResponseForError<WebPurifyCheckResponse>(
                    xml.Elements("rsp").FirstOrDefault(), new WebPurifyCheckResponse());
            }

            var count = xml.Elements("rsp").Select(x => x.Element("found").Value).FirstOrDefault();
            var expletives = (from x in xml.Descendants("expletive") select x.Value).ToArray();
            var response = new WebPurifyCheckResponse
                {
                    Count = count != null ? int.Parse(count, CultureInfo.CurrentCulture) : 0,
                    Found = count != null && (int.Parse(count, CultureInfo.CurrentCulture) > 0), 
                    Expletives = expletives
                };
            return response;
        }

        /// <summary>
        /// The create web purify get list response.
        /// </summary>
        /// <param name="xml">
        /// The xml returned from the REST request to Web Purify.
        /// </param>
        /// <returns>
        /// WebPurifyGetListResponse object
        /// </returns>
        public static WebPurifyGetListResponse CreateWebPurifyGetListResponse(XContainer xml)
        {
            if (xml.Elements("rsp").FirstOrDefault().Attribute(XName.Get("stat")).Value == "fail")
            {
                return CreateWebPurifyResponseForError<WebPurifyGetListResponse>(
                    xml.Elements("rsp").FirstOrDefault(), new WebPurifyGetListResponse());
            }

            string[] words = (from x in xml.Descendants("word") select x.Value).ToArray();
            var response = new WebPurifyGetListResponse { Words = words };
            return response;
        }

        /// <summary>
        /// The create web purify manage list response.
        /// </summary>
        /// <param name="xml">
        /// The xml returned from the REST request to Web Purify.
        /// </param>
        /// <returns>
        /// WebPurifyManageListResponse object
        /// </returns>
        public static WebPurifyManageListResponse CreateWebPurifyManageListResponse(XContainer xml)
        {
            if (xml.Elements("rsp").FirstOrDefault().Attribute(XName.Get("stat")).Value == "fail")
            {
                return CreateWebPurifyResponseForError<WebPurifyManageListResponse>(
                    xml.Elements("rsp").FirstOrDefault(), new WebPurifyManageListResponse());
            }

            string success = xml.Elements("rsp").Select(x => x.Element("success").Value).FirstOrDefault();
            var response = new WebPurifyManageListResponse { Success = success == "1" };
            return response;
        }

        /// <summary>
        /// The create web purify replace response.
        /// </summary>
        /// <param name="xml">
        /// The xml returned from the REST request to Web Purify.
        /// </param>
        /// <returns>
        /// WebPurifyReplaceResponse object
        /// </returns>
        public static WebPurifyReplaceResponse CreateWebPurifyReplaceResponse(XContainer xml)
        {
            if (xml.Elements("rsp").FirstOrDefault().Attribute(XName.Get("stat")).Value == "fail")
            {
                return CreateWebPurifyResponseForError<WebPurifyReplaceResponse>(
                    xml.Elements("rsp").FirstOrDefault(), new WebPurifyReplaceResponse());
            }

            string count = xml.Elements("rsp").Select(x => x.Element("found").Value).FirstOrDefault();
            string text = xml.Elements("rsp").Select(x => x.Element("text").Value).FirstOrDefault();
            var response = new WebPurifyReplaceResponse
                {
                   Count = count != null ? int.Parse(count) : 0, Text = text ?? string.Empty, 
                };
            return response;
        }

        /// <summary>
        /// The create web purify response for error.
        /// </summary>
        /// <param name="xml">
        /// The xml returned from the REST request to Web Purify.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <typeparam name="T">
        /// Class derived from WebPurifyReponse thta should be returned
        /// </typeparam>
        /// <returns>
        /// WebPurifyResponse derived oject
        /// </returns>
        public static T CreateWebPurifyResponseForError<T>(XElement xml, WebPurifyResponse response)
            where T : WebPurifyResponse
        {
            response.ErrorMessage = xml.Element("err").Attribute(XName.Get("msg")).Value;
            response.ErrorCode = xml.Element("err").Attribute(XName.Get("code")).Value;

            return (T)response;
        }

        #endregion
    }
}