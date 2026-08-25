using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MonitoringController : ControllerBase
{
    private readonly IMonitoringService _monitoringService;

    public MonitoringController(
        IMonitoringService monitoringService)
    {
        _monitoringService = monitoringService;
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary()
    {
       try{
       Console.WriteLine(">>> SUMMARY API CALLED 11 <<<");
        var result =
            await _monitoringService.GetSummaryAsync();

        return Ok(result);
        }
        catch (Exception ex)
    {
        Console.WriteLine(">>> SUMMARY API ERROR <<<");
        Console.WriteLine(ex.ToString());

        return StatusCode(500, new
        {
            error = ex.Message,
            innerError = ex.InnerException?.Message
        });
    }
    }
}
