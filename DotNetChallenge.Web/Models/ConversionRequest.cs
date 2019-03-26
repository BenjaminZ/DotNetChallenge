#pragma warning disable 1591
namespace DotNetChallenge.Web.Models
{
    public class ConversionRequest
    {
        public string Name { get; set; }

        /// <summary>
        ///     double between 0 and 999,999,999,999
        /// </summary>
        public decimal Amount { get; set; }
    }
}