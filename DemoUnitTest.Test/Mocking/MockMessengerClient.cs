using Business.Interface;
using Business.Models;
using Moq;

namespace DemoUnitTest.Test.Mocking;

public class MockMessengerClient : Mock<IMessengerClient>
{
    public MockMessengerClient()
    {
        Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(
            new MessageResponse()
            {
                recipient_id = "2846303288824466",
                message_id = "m_M-_LNapAvkXrY8s722CcHJHWJnHPZ9G5G2fHMu8-ySAFgw_uT130jv6uuryUB4hZli93ZRWgsK-dJsbNUDlsTg",
            });

        // Setup(x => x.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(
        //     new MessageResponse()
        //     {
        //         recipient_id = "2846303288824466",
        //         message_id = "m_M-_LNapAvkXrY8s722CcHJHWJnHPZ9G5G2fHMu8-ySAFgw_uT130jv6uuryUB4hZli93ZRWgsK-dJsbNUDlsTg",
        //     });
    }


}