
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace rest_demo.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyVaultController : ControllerBase
    {


        private readonly SecretClient _secretClient;

        public KeyVaultController(SecretClient secretClient)
        {
            _secretClient = secretClient;
        }

        [HttpGet]
        [Route("GetSecret")]
        public async Task<IActionResult> GetSecret(string secretName)
        {
            try
            {

                var secret = await _secretClient.GetSecretAsync(secretName);
                return Ok(secret.Value.Value);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving secret: {ex.Message}");
            }
        }

    }

}