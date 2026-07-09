
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;

public class AzureServiceBusController : ControllerBase
{
    [HttpPost]
    [Route("SendMessage")]
    public async Task<IActionResult> SendMessage([FromBody] string message)
    {
       string connectionString = "name";
       
       
       string queueName = "orderqueue";

        var client = new ServiceBusClient(connectionString);
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