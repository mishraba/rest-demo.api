public class LoggerService : ILoggerInterface
{
    public LoggerService()
    {
        Console.WriteLine($"LoggerService initialized.");
    }
    
    public void Log(string message)
    {
        // Implement your logging logic here
        Console.WriteLine($"Log: {message}");
    }
}   