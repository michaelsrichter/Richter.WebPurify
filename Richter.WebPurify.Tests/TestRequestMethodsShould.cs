// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestRequestMethodsShould.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The test request methods should.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Tests
{
    #region Using

    using System.Xml.Linq;

    using NUnit.Framework;

    using Richter.WebPurify.Wrapper;
    using Richter.WebPurify.Wrapper.Responses;

    #endregion

    /// <summary>
    /// The test request methods should.
    /// </summary>
    [TestFixture]
    public class TestRequestMethodsShould
    {
        #region Public Methods and Operators

        /// <summary>
        /// The return correct web purify check response for check count request.
        /// </summary>
        /// <param name="found">
        /// The found.
        /// </param>
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ReturnCorrectWebPurifyCheckResponseForCheckCountRequest(int found)
        {
            // arrange
            var expectedResponse = new WebPurifyCheckResponse
                {
                   Found = found > 0, Count = found, Expletives = new string[0] 
                };
            var xml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
                <rsp stat=""ok"">
                  <method>webpurify.live.check</method> 
                  <format>rest</format> 
                  <found>{0}</found>
                  <api_key>api_key</api_key> 
                </rsp>";
            xml = string.Format(xml, found);

            // act
            var resultResponse = WebPurifyCreateResponse.CreateWebPurifyCheckResponse(XDocument.Parse(xml));

            // assert
            Assert.AreEqual(expectedResponse.Count, resultResponse.Count);
            Assert.AreEqual(expectedResponse.Found, resultResponse.Found);
            Assert.AreEqual(expectedResponse.Expletives, resultResponse.Expletives);
        }

        /// <summary>
        /// The return correct web purify check response for check request.
        /// </summary>
        /// <param name="found">
        /// The found.
        /// </param>
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void ReturnCorrectWebPurifyCheckResponseForCheckRequest(int found)
        {
            // arrange
            var expectedResponse = new WebPurifyCheckResponse
                {
                   Found = found == 1, Count = found, Expletives = new string[0] 
                };
            var xml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
                <rsp stat=""ok"">
                  <method>webpurify.live.check</method> 
                  <format>rest</format> 
                  <found>{0}</found>
                  <api_key>api_key</api_key> 
                </rsp>";
            xml = string.Format(xml, found);

            // act
            var resultResponse = WebPurifyCreateResponse.CreateWebPurifyCheckResponse(XDocument.Parse(xml));

            // assert
            Assert.AreEqual(expectedResponse.Count, resultResponse.Count);
            Assert.AreEqual(expectedResponse.Found, resultResponse.Found);
            Assert.AreEqual(expectedResponse.Expletives, resultResponse.Expletives);
        }

        /// <summary>
        /// The return correct web purify check response for error request.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="msg">
        /// The msg.
        /// </param>
        [Test]
        [TestCase("100", "Message 100")]
        [TestCase("101", "Message 101")]
        public void ReturnCorrectWebPurifyCheckResponseForErrorRequest(string code, string msg)
        {
            // arrange
            var expectedResponse1 = new WebPurifyCheckResponse { ErrorCode = code, ErrorMessage = msg };
            var expectedResponse2 = new WebPurifyReplaceResponse { ErrorCode = code, ErrorMessage = msg };
            var expectedResponse3 = new WebPurifyManageListResponse { ErrorCode = code, ErrorMessage = msg };
            var expectedResponse4 = new WebPurifyGetListResponse { ErrorCode = code, ErrorMessage = msg };
            var xml =
                @"<?xml version=""1.0"" encoding=""utf-8""?>
	            <rsp stat=""fail"">
	                <err code=""{0}"" msg=""{1}"" />
                    <text>string</text>
                </rsp>";
            xml = string.Format(xml, code, msg);

            // act
            var resultResponse1 = WebPurifyCreateResponse.CreateWebPurifyCheckResponse(XDocument.Parse(xml));
            var resultResponse2 = WebPurifyCreateResponse.CreateWebPurifyReplaceResponse(XDocument.Parse(xml));
            var resultResponse3 = WebPurifyCreateResponse.CreateWebPurifyManageListResponse(XDocument.Parse(xml));
            var resultResponse4 = WebPurifyCreateResponse.CreateWebPurifyGetListResponse(XDocument.Parse(xml));

            // assert
            Assert.AreEqual(expectedResponse1.ErrorCode, resultResponse1.ErrorCode);
            Assert.AreEqual(expectedResponse2.ErrorCode, resultResponse2.ErrorCode);
            Assert.AreEqual(expectedResponse3.ErrorCode, resultResponse3.ErrorCode);
            Assert.AreEqual(expectedResponse4.ErrorCode, resultResponse4.ErrorCode);

            Assert.AreEqual(expectedResponse1.ErrorMessage, resultResponse1.ErrorMessage);
            Assert.AreEqual(expectedResponse2.ErrorMessage, resultResponse2.ErrorMessage);
            Assert.AreEqual(expectedResponse3.ErrorMessage, resultResponse3.ErrorMessage);
            Assert.AreEqual(expectedResponse4.ErrorMessage, resultResponse4.ErrorMessage);
        }

        /// <summary>
        /// The return correct web purify check response for get list request.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="words">
        /// The words.
        /// </param>
        [Test]
        [TestCase("webpurify.live.getblacklist", null)]
        [TestCase("webpurify.live.getblacklist", new[] { "cat" })]
        [TestCase("webpurify.live.getblacklist", new[] { "cat", "dog" })]
        [TestCase("webpurify.live.getwhitelist", new[] { "cat", "dog", "fish" })]
        [TestCase("webpurify.live.getwhitelist", new[] { "cat", "dog", "fish", "hamster" })]
        public void ReturnCorrectWebPurifyCheckResponseForGetListRequest(string method, string[] words)
        {
            // arrange
            if (words == null)
            {
                words = new string[0];
            }

            var expectedResponse = new WebPurifyGetListResponse { Words = words };
            var xml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                <rsp stat=""ok"">
                  <method>webpurify.live.getblacklist</method>
                  <format>rest</format>
                  {0}
                  <api_key>api_key</api_key>
                </rsp>";

            var wordString = string.Empty;
            foreach (var word in words)
            {
                wordString += "<word>" + word + "</word>\r\n";
            }

            xml = string.Format(xml, wordString);

            // act
            var resultResponse = WebPurifyCreateResponse.CreateWebPurifyGetListResponse(XDocument.Parse(xml));

            // assert
            Assert.AreEqual(expectedResponse.Words, resultResponse.Words);
        }

        /// <summary>
        /// The return correct web purify check response for manage list request.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="success">
        /// The success.
        /// </param>
        [Test]
        [TestCase("webpurify.live.removefromblacklist", false)]
        [TestCase("webpurify.live.removefromwhitelist", true)]
        [TestCase("webpurify.live.addtoblacklist", true)]
        [TestCase("webpurify.live.addtowhitelist", false)]
        public void ReturnCorrectWebPurifyCheckResponseForManageListRequest(string method, bool success)
        {
            // arrange
            var expectedResponse = new WebPurifyManageListResponse { Success = success };
            var xml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                <rsp stat=""ok"">
                  <method>w{0}</method>
                  <format>rest</format>
                  <success>{1}</success>
                  <api_key>api_key</api_key>
                </rsp>";
            xml = string.Format(xml, method, WebPurifyUrlParameters.ToUrl(success));

            // act
            var resultResponse = WebPurifyCreateResponse.CreateWebPurifyManageListResponse(XDocument.Parse(xml));

            // assert
            Assert.AreEqual(expectedResponse.Success, resultResponse.Success);
        }

        /// <summary>
        /// The return correct web purify check response for replace request.
        /// </summary>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        [Test]
        [TestCase(0, "")]
        [TestCase(1, "**** you")]
        [TestCase(2, "**** ***** you")]
        public void ReturnCorrectWebPurifyCheckResponseForReplaceRequest(int count, string text)
        {
            // arrange
            var expectedResponse = new WebPurifyReplaceResponse { Count = count, Text = text };
            var xml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                <rsp stat=""ok"">
                  <method>webpurify.live.replace</method>
                  <format>rest</format>
                  <found>{0}</found>
                  <text>{1}</text>
                  <api_key>api_key</api_key>
                </rsp>";
            xml = string.Format(xml, count, text);

            // act
            var resultResponse = WebPurifyCreateResponse.CreateWebPurifyReplaceResponse(XDocument.Parse(xml));

            // assert
            Assert.AreEqual(expectedResponse.Count, resultResponse.Count);
            Assert.AreEqual(expectedResponse.Text, resultResponse.Text);
        }

        /// <summary>
        /// The return correct web purify check response for return request.
        /// </summary>
        /// <param name="found">
        /// The found.
        /// </param>
        /// <param name="expletives">
        /// The expletives.
        /// </param>
        [Test]
        [TestCase(0, null)]
        [TestCase(1, new[] { "cat" })]
        [TestCase(2, new[] { "cat", "dog" })]
        [TestCase(3, new[] { "cat", "dog", "fish" })]
        [TestCase(4, new[] { "cat", "dog", "fish", "hamster" })]
        public void ReturnCorrectWebPurifyCheckResponseForReturnRequest(int found, string[] expletives)
        {
            // arrange
            if (expletives == null)
            {
                expletives = new string[0];
            }

            var expectedResponse = new WebPurifyCheckResponse
                {
                   Found = found > 0, Count = found, Expletives = expletives 
                };
            var xml =
                @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
                <rsp stat=""ok"">
                  <method>webpurify.live.check</method> 
                  <format>rest</format> 
                  <found>{0}</found>
                  {1}
                  <api_key>api_key</api_key> 
                </rsp>";

            string expletiveString = string.Empty;
            foreach (var expletive in expletives)
            {
                expletiveString += "<expletive>" + expletive + "</expletive>\r\n";
            }

            xml = string.Format(xml, found, expletiveString);

            // act
            var resultResponse = WebPurifyCreateResponse.CreateWebPurifyCheckResponse(XDocument.Parse(xml));

            // assert
            Assert.AreEqual(expectedResponse.Count, resultResponse.Count);
            Assert.AreEqual(expectedResponse.Found, resultResponse.Found);
            Assert.AreEqual(expectedResponse.Expletives, resultResponse.Expletives);
        }

        /// <summary>
        /// The setup.
        /// </summary>
        [TestFixtureSetUp]
        public void Setup()
        {
        }

        #endregion
    }
}