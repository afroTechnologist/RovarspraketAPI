using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/[controller]")]

public class RovarspraketController : ControllerBase
{
    [HttpPost("encrypt")]

    public ActionResult<string> Encrypt([FromBody] string text)

    {
        // Krypteringslogik med rövarspråket
        // Implementera krypteringsalgoritmen här
        throw new NotImplementedException();
    }
    
}