using Business.HttpClients;
using Business.Interface;
using Business.Models;

namespace Business;

public class FacebookBusiness : IFacebookBusiness
{
    private IMessengerClient _messengerClient;
    
    public FacebookBusiness(IMessengerClient messengerClient)
    {
        this._messengerClient = messengerClient;
    }

    public async Task<MessageResponse> SendMessage(string psid ,string token, string message)
    {
        if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(psid) || string.IsNullOrEmpty(token))
        {
            return null;
        }
        
        return await this._messengerClient.SendMessage(psid, token, message);
    }
}