using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace RedirectRequestFunction;

/// <summary>
///     This class contains a function that redirects an HTTP request to a specified URL.
/// </summary>
public class RedirectFunction
{
    /// <summary>
    ///     This function redirects an HTTP request to a specified URL.
    /// </summary>
    /// <param name="req">The incoming HTTP request.</param>
    /// <returns>An HTTP response with a redirect status code and the new location.</returns>
    [Function("RedirectFunction")]
    public static HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "/")]
        HttpRequestData req)
    {
        // Check if the HttpRequestData object is null
        if (req == null) throw new ArgumentNullException(nameof(req));

        // Specify the target URL for redirection
        const string url = "https://alphypay-staging.azurewebsites.net/scanAndPay/callback/razerVT";

        // Create a response with a redirect status code
        var response = req.CreateResponse(HttpStatusCode.Redirect);

        // Add the Location header for redirection
        response.Headers.Add(HttpResponseHeader.Location.ToString(), url);

        return response;
    }
}