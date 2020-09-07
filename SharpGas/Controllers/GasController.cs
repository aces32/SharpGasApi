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
    [Route("api/Gas")]
    [ApiController]
    public class GasController : ControllerBase
    {
        private readonly IGasRepository gasRepository;
        private readonly IMapper mapper;

        public GasController(IGasRepository gasRepository,
            IMapper mapper)
        {
            this.gasRepository = gasRepository;
            this.mapper = mapper;
        }

        // POST api/<GasController>
        [HttpPost]
        public ActionResult<GasResponseDto> Post(GasRecords records)
        {
            var param = mapper.Map<GasInformation>(records);
            if (gasRepository.GasAlreadyTagged(records.GasMobileNumber))
            {
                gasRepository.UpdateGasWeight(records);
                gasRepository.Commit();
            }
            else
            {
                gasRepository.InsertGasRecord(param);
                gasRepository.Commit();
            }

            var gasToReturn = mapper.Map<GasResponseDto>(param);
            return CreatedAtRoute("GetGasRecord", new { gasToReturn.GasId }, gasToReturn);

        }

        [HttpGet("{gasId}", Name = "GetGasRecord")]
        public IActionResult GetGasRecord(Guid gasId)
        {
            var gasFromRepo = gasRepository.GetGasRecord(gasId);

            if (gasFromRepo == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GasResponseDto>(gasFromRepo));
        }

    }
}
