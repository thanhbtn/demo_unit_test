using Business.Models;

namespace Business.Interface;

public interface IMessengerClient
{
    Task<MessageResponse> SendMessage(string psid, string token, string message);
}