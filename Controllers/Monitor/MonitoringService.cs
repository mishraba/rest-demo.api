using Azure.Identity;
using Azure.Monitor.Query;

public class MonitoringService : IMonitoringService
{
    private readonly LogsQueryClient _logsClient;
    private readonly string _workspaceId;

    public MonitoringService(IConfiguration configuration)
    {
        _workspaceId = configuration["ApplicationInsights:WorkspaceId"]
            ?? throw new InvalidOperationException(
                "APPLICATIONINSIGHTS__WORKSPACEID is not configured.");

        _logsClient = new LogsQueryClient(
            new DefaultAzureCredential());
    }

    public async Task<MonitoringSummaryDto> GetSummaryAsync()
    {
        Console.WriteLine(">>> MonitoringService started <<<");
        
        string query = """
            requests
            | summarize
                TotalRequests = count(),
                FailedRequests = countif(success == false),
                AverageResponseTime = avg(duration)
            """;

        var response = await _logsClient.QueryWorkspaceAsync(
            _workspaceId,
            query,
            new QueryTimeRange(TimeSpan.FromHours(24)));

        var table = response.Value.Table;

        if (table.Rows.Count == 0)
        {
            return new MonitoringSummaryDto();
        }

        var row = table.Rows[0];

        return new MonitoringSummaryDto
        {
            TotalRequests = Convert.ToInt64(row[0]),
            FailedRequests = Convert.ToInt64(row[1]),
            AverageResponseTime = Convert.ToDouble(row[2])
        };
    }
}
