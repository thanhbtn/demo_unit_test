using Business;
using Business.HttpClients;
using Business.Interface;
using DemoUnitTest.Test.Mocking;

namespace DemoUnitTest.Test;

public class FacebookBusiness_Test
{
    private IFacebookBusiness _facebookBusiness;
    private IMessengerClient _messengerClient;
    public FacebookBusiness_Test()
    {
        _messengerClient = new MockMessengerClient().Object;
        
        _facebookBusiness = new FacebookBusiness(_messengerClient);
    }
    
    [Fact]
    public async Task TestSendMessage()
    {
        var actual = await _facebookBusiness.SendMessage("123", "tk", "msg");
        Assert.NotEqual(actual, null);
    }
    
    [Fact]
    public async Task SendMessage()
    {
        var actual = await _facebookBusiness.SendMessage("123", "tk", "msg");
        Assert.NotEqual(actual, null);
    }
    
    [Theory]
    [InlineData("", "", "")]
    [InlineData("1", "", "")]
    [InlineData("", "1", "")]
    [InlineData("", "", "1")]
    [InlineData("1", "1", "")]
    [InlineData("", "1", "1")]
    public async Task SendMessage_Failed(string psid, string token, string message)
    {
        var actual = await _facebookBusiness.SendMessage(psid, token, message);
        Assert.Equal(actual, null);
    }
}