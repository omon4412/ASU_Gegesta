using Microsoft.AspNetCore.Mvc;

namespace ASU_Degesta.Models.Controllers;

[ApiController]
[Route("api")]
public class ApiController : Controller
{
    [HttpGet]
    public JsonResult GetApiInfo()
    {
        var info = new {Status =true, ServerDate = DateTime.Now};
        
        return new JsonResult(info);
    }
}