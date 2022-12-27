using Business.Helpers;
using Business.Interface;
using Business.Models;

namespace Business.HttpClients;

public class MessengerClient : IMessengerClient
{
    private readonly HttpClient _httpClient;
    private readonly string URL = "https://graph.facebook.com/v13.0";
    
    public MessengerClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<MessageResponse> SendMessage(string psid ,string token, string message)
    {
        var url = $"{URL}/me/messages?access_token=" + token;
        var data = new
        {
            recipient = new
            {
                id = psid
            },
            message = new
            {
                text = message
            }
        };
        var result = await _httpClient.SendRequest<MessageResponse>(url, HttpMethod.Post, data);
        
        return result.Item1;
    }
}