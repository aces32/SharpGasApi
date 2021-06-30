using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Services.WebApi.Jwt;
using SharpGas.Encryption;
using SharpGasCore.Models;
using SharpGasData.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpGas.Controllers
{
    /// <summary>
    ///  authenticate users before generating token for specified api calls
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;
        private readonly IAuthenticationRepository authenticationRepository;
        private readonly ILogger<AuthenticationController> logger;

        /// <summary>
        /// AuthenticationController
        /// </summary>
        /// <param name="authenticationService"></param>
        /// <param name="authenticationRepository"></param>
        /// <param name="logger"></param>
        public AuthenticationController(AuthenticationService authenticationService,
            IAuthenticationRepository authenticationRepository, ILogger<AuthenticationController> logger)
        {
            this.authenticationService = authenticationService;
            this.authenticationRepository = authenticationRepository;
            this.logger = logger;
        }

        /// <summary>
        /// endpoint toauthenticate users before generating token for specified api calls
        /// </summary>
        /// <param name="userCredentials"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<DefaultResponse<AuthenticationResponseDto>>> Authenticate([FromBody] UserCredentials userCredentials)
        {
            try
            {
                var validateAPIUsr = await authenticationRepository.AuthenticateAsync(userCredentials);
                if (validateAPIUsr == null)
                {
                    return StatusCode(500, new DefaultResponse<AuthenticationResponseDto>
                    {
                        Message = "An error occured validating Api User"
                    });
                }
                else if (validateAPIUsr.ToList().Count <= 0)
                {
                    return StatusCode(404, new DefaultResponse<AuthenticationResponseDto>
                    {
                        Message = "Invalid Api User"
                    });
                }
                else
                {
                    var (token, expiryPeriod) = authenticationService.Authenticate(validateAPIUsr.FirstOrDefault().expiryLength);
                    return Ok(new DefaultResponse<AuthenticationResponseDto>
                    {
                        Message = "Success",
                        Data = new AuthenticationResponseDto
                        {
                            BearerToken = token,
                            ExpiryPeriod = expiryPeriod
                        }
                    });
                }

            }
            catch (InvalidCredentialsException ex)
            {
                logger.LogError(ex, $"Exception occurred at AuthController {nameof(Authenticate)} method");
                return Unauthorized();
            }
        }
    }
}
