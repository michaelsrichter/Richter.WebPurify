// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestGetUrlsShould.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The test get urls should.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Tests
{
    #region Using

    using NUnit.Framework;

    using Richter.WebPurify.Wrapper;
    using Richter.WebPurify.Wrapper.Interfaces;

    #endregion

    /// <summary>
    /// The test get urls should.
    /// </summary>
    [TestFixture]
    public class TestGetUrlsShould
    {
        #region Constants and Fields

        /// <summary>
        ///   The _api url.
        /// </summary>
        private string _apiUrl = "http://api1.webpurify.com/services/rest/";

        /// <summary>
        ///   The _apikey.
        /// </summary>
        private string _apikey = "value";

        /// <summary>
        ///   The _request.
        /// </summary>
        private WebPurifyRequest _request;

        /// <summary>
        ///   The _service.
        /// </summary>
        private IWebPurifyService _service;

        /// <summary>
        ///   The _text.
        /// </summary>
        private string _text = "string";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The generate correct check url.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="methodname">
        /// The methodname.
        /// </param>
        /// <param name="semail">
        /// The semail.
        /// </param>
        /// <param name="sphone">
        /// The sphone.
        /// </param>
        /// <param name="lang">
        /// The lang.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        [Test]
        [TestCase(WebPurifyCheckMethod.Check, "webpurify.live.check", true, true, "en", 
            WebPurifySupportedLanguage.English)]
        [TestCase(WebPurifyCheckMethod.Check, "webpurify.live.check", false, true, "es", 
            WebPurifySupportedLanguage.Spanish)]
        [TestCase(WebPurifyCheckMethod.Check, "webpurify.live.check", true, false, "it", 
            WebPurifySupportedLanguage.Italian)]
        [TestCase(WebPurifyCheckMethod.CheckCount, "webpurify.live.checkcount", true, true, "fr", 
            WebPurifySupportedLanguage.French)]
        [TestCase(WebPurifyCheckMethod.Return, "webpurify.live.return", false, true, "ar", 
            WebPurifySupportedLanguage.Arabic)]
        [TestCase(WebPurifyCheckMethod.Return, "webpurify.live.return", true, false, "en", 
            WebPurifySupportedLanguage.English)]
        public void GenerateCorrectCheckUrl(
            WebPurifyCheckMethod method, 
            string methodname, 
            bool semail, 
            bool sphone, 
            string lang, 
            WebPurifySupportedLanguage language)
        {
            // arrange
            const string urlCheckFormat = "{0}?method={1}&api_key={2}&text={3}&semail={4}&sphone={5}&lang={6}";
            string expectedurl = string.Format(
                urlCheckFormat, 
                _apiUrl, 
                methodname, 
                _apikey, 
                _text, 
                WebPurifyUrlParameters.ToUrl(semail), 
                WebPurifyUrlParameters.ToUrl(sphone), 
                lang);

            // act
            string resulturl = _request.GetCheckUrl(_text, method, semail, sphone, language);

            // assert
            Assert.AreEqual(expectedurl, resulturl);
        }

        /// <summary>
        /// The generate correct get list url.
        /// </summary>
        /// <param name="methodname">
        /// The methodname.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        [Test]
        [TestCase("webpurify.live.getblacklist", WebPurifyListType.Black)]
        [TestCase("webpurify.live.getwhitelist", WebPurifyListType.White)]
        public void GenerateCorrectGetListUrl(string methodname, WebPurifyListType type)
        {
            // arrange
            const string url = "{0}?method={1}&api_key={2}";
            string expectedurl = string.Format(url, _apiUrl, methodname, _apikey);

            // act
            string resulturl = _request.GetGetMethodUrl(type);

            // assert
            Assert.AreEqual(expectedurl, resulturl);
        }

        /// <summary>
        /// The generate correct manage list url.
        /// </summary>
        /// <param name="methodname">
        /// The methodname.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="word">
        /// The word.
        /// </param>
        [Test]
        [TestCase("webpurify.live.addtoblacklist", WebPurifyListMethod.Add, WebPurifyListType.Black, "dark")]
        [TestCase("webpurify.live.removefromblacklist", WebPurifyListMethod.Remove, WebPurifyListType.Black, "dark")]
        [TestCase("webpurify.live.addtowhitelist", WebPurifyListMethod.Add, WebPurifyListType.White, "light")]
        [TestCase("webpurify.live.removefromwhitelist", WebPurifyListMethod.Remove, WebPurifyListType.White, "light")]
        public void GenerateCorrectManageListUrl(
            string methodname, WebPurifyListMethod method, WebPurifyListType type, string word)
        {
            // arrange
            const string url = "{0}?method={1}&api_key={2}&word={3}";
            string expectedurl = string.Format(url, _apiUrl, methodname, _apikey, word);

            // act
            string resulturl = _request.GetManageListUrl(method, type, word);

            // assert
            Assert.AreEqual(expectedurl, resulturl);
        }

        /// <summary>
        /// The generate correct replace url.
        /// </summary>
        /// <param name="replacesymbol">
        /// The replacesymbol.
        /// </param>
        /// <param name="cdata">
        /// The cdata.
        /// </param>
        /// <param name="semail">
        /// The semail.
        /// </param>
        /// <param name="sphone">
        /// The sphone.
        /// </param>
        /// <param name="lang">
        /// The lang.
        /// </param>
        /// <param name="language">
        /// The language.
        /// </param>
        [Test]
        [TestCase('@', true, false, true, "en", WebPurifySupportedLanguage.English)]
        [TestCase('*', true, true, false, "ar", WebPurifySupportedLanguage.Arabic)]
        [TestCase('!', false, true, true, "fr", WebPurifySupportedLanguage.French)]
        [TestCase('#', true, false, false, "it", WebPurifySupportedLanguage.Italian)]
        [TestCase('%', false, false, true, "es", WebPurifySupportedLanguage.Spanish)]
        public void GenerateCorrectReplaceUrl(
            char replacesymbol, bool cdata, bool semail, bool sphone, string lang, WebPurifySupportedLanguage language)
        {
            // arrange
            const string urlReplaceFormat =
                "{0}?method={1}&api_key={2}&text={3}&replacesymbol={4}&cdata={5}&semail={6}&sphone={7}&lang={8}";
            string expectedurl = string.Format(
                urlReplaceFormat, 
                _apiUrl, 
                "webpurify.live.replace", 
                _apikey, 
                _text, 
                replacesymbol, 
                WebPurifyUrlParameters.ToUrl(cdata), 
                WebPurifyUrlParameters.ToUrl(semail), 
                WebPurifyUrlParameters.ToUrl(sphone), 
                lang);

            // act
            string resulturl = _request.GetReplaceUrl(_text, replacesymbol, cdata, semail, sphone, language);

            // assert
            Assert.AreEqual(expectedurl, resulturl);
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