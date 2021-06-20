using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGasCore.Models;
using SharpGasData.Entites;
using SharpGasData.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpGas.Controllers
{
    //[Authorize]
    /// <summary>
    /// Onboard shapgas customers
    /// </summary>
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OnboardingController : ControllerBase
    {
        private readonly IOnboardingRepository onboarding;
        private readonly IMapper mapper;
        private readonly ILogger<OnboardingController> logger;
        string a = 2.ToString();


        /// <summary>
        /// OnboardingController
        /// </summary>
        /// <param name="onboarding"></param>
        /// <param name="mapper"></param>
        public OnboardingController(IOnboardingRepository onboarding,
            IMapper mapper, ILogger<OnboardingController> logger)
        {
            this.onboarding = onboarding;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Endpoint used to authenticate SharpGas Customers loggin in
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost, Route("api/Onboarding/Login")]

        public async Task<ActionResult<DefaultResponse<IEnumerable<LoginResponseDto>>>> SharpGasLogin(LoginDto login)
        {
            try
            {
                var customer = await onboarding.LoginAsync(login);
                if (customer.ToList().Count == 0)
                {
                    return StatusCode(400, new DefaultResponse<IEnumerable<LoginResponseDto>>
                    {
                        Message = "Invalid username or password"
                    });
                }

                return Ok(new DefaultResponse<IEnumerable<LoginResponseDto>>
                {
                    Message = "Login Successfully",
                    Data = mapper.Map<IEnumerable<LoginResponseDto>>(customer)
                });

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception occurred at OnboardingController {nameof(SharpGasLogin)} method");
                return StatusCode(500, new DefaultResponse<IEnumerable<LoginResponseDto>>
                {
                    Message = "System Error, Please try again later"
                });
            }

        }

        /// <summary>
        /// Endpoint to signup new sharpgas customers
        /// </summary>
        /// <param name="signUp"></param>
        /// <returns></returns>
        [HttpPost, Route("api/Onboarding/SignUp")]
        public async Task<ActionResult<DefaultResponse<SignUpResponseDto>>> SharpGasSignUp(SignUpDto signUp)
        {
            try
            {
                if (await onboarding.CustomerExistAsync(signUp.Email.Trim()))
                {
                    return StatusCode(409, new DefaultResponse<SignUpResponseDto> { Message = "Email Already Exist" });
                }

                var param = mapper.Map<Customers>(signUp);
                await onboarding.SignUp(param);
                var customerToReturn = mapper.Map<SignUpResponseDto>(param);
                return CreatedAtRoute("GetCustomer", new { customerToReturn.CustomerId },
                        new DefaultResponse<SignUpResponseDto>
                        {
                            Message = "Sign up successful",
                            Data = customerToReturn

                        });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception occurred at OnboardingController {nameof(SharpGasSignUp)} method");
                return StatusCode(500, new DefaultResponse<SignUpResponseDto>
                {
                    Message = "System Error, Please try again later"
                });
            }


        }

        /// <summary>
        /// Endpoint to get already or newly created customers based on customerid
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("api/Onboarding/{CustomerId}", Name = "GetCustomer")]
        public async Task<ActionResult<DefaultResponse<SignUpResponseDto>>> GetCustomer(Guid customerId)
        {
            try
            {
                var customerFromRepo = await onboarding.GetCustomerAsync(customerId);

                if (customerFromRepo.FirstOrDefault() == null)
                {
                    return StatusCode(400, new DefaultResponse<SignUpResponseDto>
                    {
                        Message = "Record not found",
                    });
                }

                return Ok(new DefaultResponse<SignUpResponseDto>
                {
                    Message = "Sign Up successful",
                    Data = mapper.Map<SignUpResponseDto>(customerFromRepo.FirstOrDefault())
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception occurred at OnboardingController {nameof(GetCustomer)} method");
                return StatusCode(500, new DefaultResponse<SignUpResponseDto>
                {
                    Message = "System Error, Please try again later"
                });
            }

        }

    }
}
