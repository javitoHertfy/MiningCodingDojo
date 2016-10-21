using RestSharp;
using System.Net;

namespace Javito.MiningCodingDojo.ResilientClient.Alain
{
    public static class RestResponseExtension
    {
        public static bool IsReponseOk(this IRestResponse iRestResponse)
        {
            var result = (iRestResponse.ResponseStatus == ResponseStatus.Completed
                && (iRestResponse.StatusCode == HttpStatusCode.OK || iRestResponse.StatusCode == HttpStatusCode.NoContent));
            return result;
        }
    }
}
