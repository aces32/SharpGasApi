using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpGasCore.Models;
using SharpGasData.Entites;
using SharpGasData.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharpGas.Controllers
{
    /// <summary>
    /// endpoint to store gas weight at specific intervals of time
    /// </summary>
    [Route("api/Gas")]
    [ApiController]
    public class GasController : ControllerBase
    {
        private readonly IGasRepository gasRepository;
        private readonly IMapper mapper;
        private readonly ILogger<GasController> logger;

        /// <summary>
        /// GasController
        /// </summary>
        /// <param name="gasRepository"></param>
        /// <param name="mapper"></param>
        public GasController(IGasRepository gasRepository,
            IMapper mapper, ILogger<GasController> logger)
        {
            this.gasRepository = gasRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// endpoint to store gas weight at specific intervals of time
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DefaultResponse<GasResponseDto>>> Post(GasRecords records)
        {
            try
            {
                var param = mapper.Map<GasInformation>(records);
                if (gasRepository.GasAlreadyTagged(records.GasMobileNumber))
                {
                    gasRepository.UpdateGasWeight(records);
                    await gasRepository.Commit();
                }
                else
                {
                    gasRepository.InsertGasRecord(param);
                    await gasRepository.Commit();
                }

                var gasToReturn = mapper.Map<GasResponseDto>(param);
                return CreatedAtRoute("GetGasRecord", new { gasToReturn.GasId }, gasToReturn);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception occurred at GasController {nameof(Post)} method");
                return StatusCode(500, new DefaultResponse<GasResponseDto>
                {
                    Message = "System Error, Please try again later"
                });
            }

        }
        /// <summary>
        /// Get gas weight record based on specified gas id
        /// </summary>
        /// <param name="gasId"></param>
        /// <returns></returns>
        [HttpGet("{gasId}", Name = "GetGasRecord")]
        public async Task<ActionResult<DefaultResponse<GasResponseDto>>> GetGasRecord(int gasId)
        {
            try
            {
                var gasFromRepo = await gasRepository.GetGasRecord(gasId);

                if (gasFromRepo == null)
                {
                    return NotFound(new DefaultResponse<GasResponseDto> { Message = "No record of found" });
                }
                else if (gasFromRepo.Count == 0)
                {
                    return NotFound(new DefaultResponse<GasResponseDto> { Message = "No record of found" });
                }

                return Ok(new DefaultResponse<GasResponseDto>
                {
                    Message = "Gas recorded successfully",
                    Data = mapper.Map<GasResponseDto>(gasFromRepo.FirstOrDefault())
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception occurred at GasController {nameof(GetGasRecord)} method");
                return StatusCode(500, new DefaultResponse<GasResponseDto>
                {
                    Message = "System Error, Please try again later"
                });
            }

        }

        [HttpGet("byVendorID")]
        public async Task<ActionResult<DefaultResponse<GasResponseDto>>> Get(int vendorID)
        {
            try
            {
                var gasFromRepo = await gasRepository.GetGasRecord(vendorID);

                //if (gasFromRepo == null)
                //{
                //    return NotFound(new DefaultResponse<GasResponseDto> { Message = "No record of found" });
                //}
                //else if (gasFromRepo.Count == 0)
                //{
                //    return NotFound(new DefaultResponse<GasResponseDto> { Message = "No record of found" });
                //}

                return Ok(new DefaultResponse<GasResponseDto>
                {
                    Message = "Gas recorded successfully",
                    Data = mapper.Map<GasResponseDto>(gasFromRepo.FirstOrDefault())
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception occurred at GasController {nameof(GetGasRecord)} method");
                return StatusCode(500, new DefaultResponse<GasResponseDto>
                {
                    Message = "System Error, Please try again later"
                });
            }

        }

    }
}
