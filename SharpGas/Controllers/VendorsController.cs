using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGasCore.Models;
using SharpGasData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpGas.Controllers
{
    /// <summary>
    /// Controller for vendors information
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorRepository ivendorrepository;
        private readonly ILogger<VendorsController> logger;
        private readonly IMapper mapper;

        /// <summary>
        /// Vendors controllers
        /// </summary>
        /// <param name="ivendorrepository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public VendorsController(IVendorRepository ivendorrepository, ILogger<VendorsController> logger,
            IMapper mapper)
        {
            this.ivendorrepository = ivendorrepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get all active vendors avaailable
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<DefaultResponse<IEnumerable<VendorsResponseDto>>>> Get()
        {
            try
            {
                var vendorList = await ivendorrepository.GetAllVendors();
                if (!vendorList.Any())
                {
                    return NotFound(new DefaultResponse<IEnumerable<VendorsResponseDto>> { Message = "No active vendors found" });
                }
                else
                {
                    return Ok(new DefaultResponse<IEnumerable<VendorsResponseDto>>
                    {
                        Message = "All vendors successfully returned",
                        Data = mapper.Map<IEnumerable<VendorsResponseDto>>(vendorList)
                    }); ;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception occurred at VendorsController {nameof(Get)} method");
                return StatusCode(500, new DefaultResponse<IEnumerable<VendorsResponseDto>>
                {
                    Message = "System Error, Please try again later"
                });
            }
        }

        // GET api/<VendorsController>/5
        //[HttpGet("{Country}/{State}/{LGA}")]
        [HttpGet("byCountryDetails")]
        public string Get(string country, string state, string lga)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return "value";
        }

        // POST api/<VendorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VendorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

    }
}
