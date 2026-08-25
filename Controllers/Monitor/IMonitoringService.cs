public interface IMonitoringService
{
    Task<MonitoringSummaryDto> GetSummaryAsync();
}