using Business.Models;

namespace Business.Interface;

public interface IFacebookBusiness
{
    Task<MessageResponse> SendMessage(string psid, string token, string message);
}