using Microsoft.AspNetCore.Mvc;
using security_jwt;

namespace test.Controllers;

[ApiController]
[Route("jwt")]
public class TestController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get([FromServices] IJwtService jwt,  string user, string password)
    {
        if ( user != "don" || password != "platinado")
            return NotFound();
        UserInfo userinfo = new UserInfo();
        userinfo.ID = 1;
        userinfo.IsAdm = true;
        return Ok(jwt.GetToken(userinfo));
    }

    [HttpGet("validate/{jwtt}")]
    public ActionResult<UserInfo> Validate([FromServices] IJwtService ijwt, string jwtt)
    {
        UserInfo a = ijwt.Validate<UserInfo>(jwtt);

        return Ok(a);
    }
}


public class UserInfo
{
    public int ID { get; set; }
    public bool IsAdm { get; set; }
}