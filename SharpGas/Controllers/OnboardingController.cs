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
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        private readonly IOnboardingRepository onboarding;
        private readonly IMapper mapper;

        public OnboardingController(IOnboardingRepository onboarding,
            IMapper mapper)
        {
            this.onboarding = onboarding;
            this.mapper = mapper;
        }

        [HttpPost, Route("api/Onboarding/Login")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<ActionResult<IEnumerable<LoginResponseDto>>> SharpGasLogin(LoginDto login)
        {
            var customer = await onboarding.LoginAsync(login);
            if (customer.ToList().Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<IEnumerable<LoginResponseDto>>(customer));
        }

        [HttpPost, Route("api/Onboarding/SignUp")]
        public async Task<ActionResult<SignUpResponseDto>> SharpGasSignUp(SignUpDto signUp)
        {
            if (await onboarding.CustomerExistAsync(signUp.email.Trim()))
            {
                return StatusCode(409, new SignUpResponseDto { ResponseDescription = "Email Already Exist" });
            }

            var param = mapper.Map<Customers>(signUp);
            onboarding.SignUp(param);
            await onboarding.CommitAsync();
            var customerToReturn = mapper.Map<SignUpResponseDto>(param);
            return CreatedAtRoute("GetCustomer", new { customerToReturn.CustomerId }, customerToReturn);

        }

        [HttpGet("{CustomerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var customerFromRepo = await onboarding.GetCustomerAsync(customerId);

            if (customerFromRepo.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<SignUpResponseDto>(customerFromRepo.FirstOrDefault()));
        }

    }
}
