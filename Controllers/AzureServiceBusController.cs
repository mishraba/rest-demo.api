
using Azure.Messaging.ServiceBus;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;

public class AzureServiceBusController : ControllerBase
{
    
    private readonly SecretClient _secretClient;

    public AzureServiceBusController(SecretClient secretClient)
    {
        _secretClient = secretClient;
    }

    [HttpPost]
    [Route("SendMessage")]
    public async Task<IActionResult> SendMessage([FromBody] string message)
    {
       //KeyVaultSecret secret = await _secretClient.GetSecretAsync("ServiceBusConnectionString");
       string queueName = "orderqueue";

        var client = new ServiceBusClient("Endpoint=sb://asb-mishraba.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3JBIh0oB5h7gkGbvJYOMjiQ5we1F50t2p+ASbCRh3nE=");
        var sender = client.CreateSender(queueName);

        try
        {
            // Create a new message to send to the queue
            var serviceBusMessage = new ServiceBusMessage(message);

            // Send the message to the queue
            await sender.SendMessageAsync(serviceBusMessage);

            return Ok("Message sent successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error sending message: {ex.Message}");
        }
        finally
        {
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }

    }
}
