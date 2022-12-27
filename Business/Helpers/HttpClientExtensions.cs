using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Business.Helpers;

public static class HttpClientExtensions
{

    public static async Task<(T, HttpStatusCode)> SendRequest<T>(this HttpClient httpClient, string url,
        HttpMethod method,
        object data = null)
    {
        
        var (content, status) = await _sendRequest(httpClient, url, method, data);
        return (content != null ? JsonConvert.DeserializeObject<T>(content) : default(T), status);
    }


    private static async Task<(string, HttpStatusCode)> _sendRequest(HttpClient httpClient, string url,
        HttpMethod method,
        object data = null)
    {
        try
        {
            var rq = new HttpRequestMessage(method, url);
            rq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (data != null)
            {
                var body = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                
                rq.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            using (var rsp = await httpClient.SendAsync(rq))
            {
                if (rsp.IsSuccessStatusCode)
                    return (await rsp.Content.ReadAsStringAsync(), rsp.StatusCode);
                else
                    return (null, rsp.StatusCode);
            }
        }
        catch (OperationCanceledException ex)
        {
            return (null, HttpStatusCode.RequestTimeout);
        }
        catch (Exception)
        {
            throw;
        }
    }
}