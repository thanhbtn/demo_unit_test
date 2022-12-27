using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Business.HttpClients;

public class BaseClient
{
    protected readonly HttpClient _httpClient;

    public BaseClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(T, HttpStatusCode)> SendRequest<T>(string url, HttpMethod method,
        string data = null)
    {
        var (content, status) = await _sendRequest(url, method, data);
        return (content != null ? JsonConvert.DeserializeObject<T>(content) : default(T), status);
    }

    
    private async Task<(string, HttpStatusCode)> _sendRequest(string url, HttpMethod method,
        string data = null)
    {
        try
        {
            var rq = new HttpRequestMessage(method, url);
            rq.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (data != null)
                rq.Content = new StringContent(data, Encoding.UTF8, "application/json");

            using (var rsp = await _httpClient.SendAsync(rq))
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
