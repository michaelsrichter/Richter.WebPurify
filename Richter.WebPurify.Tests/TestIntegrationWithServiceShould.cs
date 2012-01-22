// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestIntegrationWithServiceShould.cs" company="">
//   
// </copyright>
// <summary>
//   The test integration with service should.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Tests
{
    #region Using

    using System.Linq;
    using System.Xml.Linq;

    using NUnit.Framework;

    using Richter.WebPurify.Wrapper;
    using Richter.WebPurify.Wrapper.Interfaces;
    using Richter.WebPurify.Wrapper.Responses;

    #endregion

    /// <summary>
    /// The test integration with service should.
    /// </summary>
    [TestFixture]
    public class TestIntegrationWithServiceShould
    {
        #region Constants and Fields

        /// <summary>
        ///   The _api url.
        /// </summary>
        private string _apiUrl = "http://api1.webpurify.com/services/rest/";

        /// <summary>
        ///   The _apikey.
        /// </summary>
        private string _apikey = "977fc3d43a46c52b873cf42ec0acc8c9";

        /// <summary>
        ///   The _request.
        /// </summary>
        private WebPurifyRequest _request;

        /// <summary>
        ///   The _service.
        /// </summary>
        private IWebPurifyService _service;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add word to black list get word from black list remove word from black list.
        /// </summary>
        [Test]
        public void AddWordToBlackListGetWordFromBlackListRemoveWordFromBlackList()
        {
            const string Word = "kerfuffle";
            var addResponse = _request.ManageList(WebPurifyListMethod.Add, WebPurifyListType.Black, Word);
            var getVeryifyAddedResponse = _request.GetList(WebPurifyListType.Black);
            var checkResponse = _request.Check(Word, WebPurifyCheckMethod.Check);
            var removeResponse = _request.ManageList(WebPurifyListMethod.Remove, WebPurifyListType.Black, Word);
            var getVerifyRemovedResponse = _request.GetList(WebPurifyListType.Black);

            Assert.IsTrue(addResponse.Success);
            Assert.IsTrue(getVeryifyAddedResponse.Words.Contains(Word));
            Assert.IsTrue(checkResponse.Found);
            Assert.IsTrue(removeResponse.Success);
            Assert.IsFalse(getVerifyRemovedResponse.Words.Contains(Word));
        }

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
        /// <param name="text">
        /// The text.
        /// </param>
        [Test]
        [TestCase(false, "this has no bad words")]
        public void ReturnCorrectWebPurifyCheckResponseForCheckRequest(bool found, string text)
        {
            // arrange
            var expectedResponse = new WebPurifyCheckResponse
                {
                   Found = found, Count = found ? 1 : 0, Expletives = new string[0] 
                };

            // act
            var resultResponse = _request.Check(text, WebPurifyCheckMethod.Check);

            // assert
            Assert.AreEqual(expectedResponse.Count, resultResponse.Count);
            Assert.AreEqual(expectedResponse.Found, resultResponse.Found);
            Assert.AreEqual(expectedResponse.Expletives, resultResponse.Expletives);
        }

        /// <summary>
        /// The return correct web purify check response for manage list request.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="word">
        /// The word.
        /// </param>
        /// <param name="success">
        /// The success.
        /// </param>
        [Test]
        [TestCase(WebPurifyListMethod.Add, WebPurifyListType.White, "jupiter", true)]
        [TestCase(WebPurifyListMethod.Add, WebPurifyListType.White, "saturn", true)]
        [TestCase(WebPurifyListMethod.Add, WebPurifyListType.White, "neptune", true)]
        public void ReturnCorrectWebPurifyCheckResponseForManageListRequest(
            WebPurifyListMethod method, WebPurifyListType type, string word, bool success)
        {
            // arrange
            var expectedResponse = new WebPurifyManageListResponse { Success = success };

            // act
            var resultResponse = _request.ManageList(WebPurifyListMethod.Add, WebPurifyListType.White, word);

            // assert
            Assert.AreEqual(expectedResponse.Success, resultResponse.Success);
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
            _service = new WebPurifyService();
            _request = new WebPurifyRequest(_apiUrl, _apikey, _service);
        }

        #endregion
    }
}