using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// GasController
        /// </summary>
        /// <param name="gasRepository"></param>
        /// <param name="mapper"></param>
        public GasController(IGasRepository gasRepository,
            IMapper mapper)
        {
            this.gasRepository = gasRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// endpoint to store gas weight at specific intervals of time
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GasResponseDto>> Post(GasRecords records)
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
        /// <summary>
        /// Get gas weight record based on specified id
        /// </summary>
        /// <param name="gasId"></param>
        /// <returns></returns>
        [HttpGet("{gasId}", Name = "GetGasRecord")]
        public async Task<ActionResult<GasResponseDto>> GetGasRecord(int gasId)
        {
            var gasFromRepo = await gasRepository.GetGasRecord(gasId);

            if (gasFromRepo == null)
            {
                return NotFound();
            }
            else if (gasFromRepo.Count == 0)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GasResponseDto>(gasFromRepo.FirstOrDefault()));
        }

    }
}
