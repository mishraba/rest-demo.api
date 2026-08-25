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
       Console.WriteLine(">>> SUMMARY API CALLED <<<");
        var result =
            await _monitoringService.GetSummaryAsync();

        return Ok(result);
    }
}
