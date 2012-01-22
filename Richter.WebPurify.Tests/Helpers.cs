// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Helpers.cs" company="Michael S. Richter">
//   Michael S. Richter
// </copyright>
// <summary>
//   The helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Richter.WebPurify.Tests
{
    /// <summary>
    /// The helpers.
    /// </summary>
    public static class Helpers
    {
        #region Public Methods and Operators

        /// <summary>
        /// The to url.
        /// </summary>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <returns>
        /// The to url.
        /// </returns>
        public static string ToUrl(this bool b)
        {
            return b ? "1" : "0";
        }

        #endregion
    }
}