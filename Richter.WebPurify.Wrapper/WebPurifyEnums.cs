// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebPurifyEnums.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The web purify argument.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Wrapper
{
    /// <summary>
    /// The web purify argument.
    /// </summary>
    public enum WebPurifyArgument
    {
        /// <summary>
        /// The api key.
        /// </summary>
        ApiKey, 

        /// <summary>
        /// The text.
        /// </summary>
        Text, 

        /// <summary>
        /// The language.
        /// </summary>
        Language, 

        /// <summary>
        /// The check email.
        /// </summary>
        CheckEmail, 

        /// <summary>
        /// The check phone.
        /// </summary>
        CheckPhone, 

        /// <summary>
        /// The replace symbol.
        /// </summary>
        ReplaceSymbol, 

        /// <summary>
        /// The c data wrap.
        /// </summary>
        CDataWrap, 

        /// <summary>
        /// The list word.
        /// </summary>
        ListWord
    }

    /// <summary>
    /// The web purify check method.
    /// </summary>
    public enum WebPurifyCheckMethod
    {
        /// <summary>
        /// The check.
        /// </summary>
        Check, 

        /// <summary>
        /// The check count.
        /// </summary>
        CheckCount, 

        /// <summary>
        /// The return.
        /// </summary>
        Return
    }

    /// <summary>
    /// The web purify supported language.
    /// </summary>
    public enum WebPurifySupportedLanguage
    {
        /// <summary>
        /// The english language.
        /// </summary>
        English, 

        /// <summary>
        /// The spanish language.
        /// </summary>
        Spanish, 

        /// <summary>
        /// The arabic language.
        /// </summary>
        Arabic, 

        /// <summary>
        /// The italian language.
        /// </summary>
        Italian, 

        /// <summary>
        /// The french language.
        /// </summary>
        French
    }

    /// <summary>
    /// The web purify list method.
    /// </summary>
    public enum WebPurifyListMethod
    {
        /// <summary>
        /// The addto method.
        /// </summary>
        Add, 

        /// <summary>
        /// The removefrom method.
        /// </summary>
        Remove
    }

    /// <summary>
    /// The web purify list type.
    /// </summary>
    public enum WebPurifyListType
    {
        /// <summary>
        /// The whitelist.
        /// </summary>
        White, 

        /// <summary>
        /// The blacklist.
        /// </summary>
        Black
    }
}