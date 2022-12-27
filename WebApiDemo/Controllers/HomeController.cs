using Business.Interface;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers;

[ApiController]
public class HomeController  : ControllerBase
{
    private IFacebookBusiness _facebookBusiness;
    
    public HomeController(IFacebookBusiness facebookBusiness)
    {
        this._facebookBusiness = facebookBusiness;
    }
    
    [HttpPost]
    [Route("/send_msg")]
    public async Task<IActionResult> SendMsg([FromBody] SendMsgModel model)
    {
        var data = await _facebookBusiness.SendMessage(model?.psid, model?.token, model?.message);
        return Ok(data != null
            ? data
            : new
            {
                error = "send failed"
            });
    }
}