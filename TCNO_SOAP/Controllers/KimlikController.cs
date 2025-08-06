using Microsoft.AspNetCore.Mvc;
using TCNO_SOAP.Models;

[ApiController]
[Route("api/[controller]")]
public class KimlikController : ControllerBase
{
    private readonly TcDogrulamaService _tcService;

    public KimlikController(TcDogrulamaService tcService)
    {
        _tcService = tcService;
    }

    [HttpPost("dogrula")]
    public IActionResult Dogrula([FromBody] KimlikModel model)
    {
        var sonuc = _tcService.Dogrula(model.TC, model.Ad, model.Soyad, model.DogumYili);
        return Ok(new { GecerliMi = sonuc });
    }
}
