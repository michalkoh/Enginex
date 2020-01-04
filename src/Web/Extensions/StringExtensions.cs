using System.Web;

namespace Enginex.Web.Extensions
{
    internal static class StringExtensions
    {
        public static string ReplaceQueryStringParameter(this string url, string parameter, string value)
        {
            var urlWithoutQuery = url.IndexOf('?') >= 0
                ? url.Substring(0, url.IndexOf('?'))
                : url;

            var queryString = url.IndexOf('?') >= 0
                ? url.Substring(url.IndexOf('?'))
                : null;

            var queryParamList = queryString != null
                ? HttpUtility.ParseQueryString(queryString)
                : HttpUtility.ParseQueryString(string.Empty);

            if (queryParamList[parameter] != null)
            {
                queryParamList[parameter] = value;
            }
            else
            {
                queryParamList.Add(parameter, value);
            }

            return $"{urlWithoutQuery}?{queryParamList}";
        }
    }
}
