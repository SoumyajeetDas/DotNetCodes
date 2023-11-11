using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyWebAPI.Models;
using ParkyWebAPI.Models.DTOs;
using ParkyWebAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWebAPI.Controllers
{
    // Here all the DTOs are created so that 

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class TrailsController : ControllerBase
    {
        private ITrailRepository trailRepo;
        private IMapper mapper;
        public TrailsController(ITrailRepository trailRepo, IMapper mapper)
        {
            this.trailRepo = trailRepo;
            this.mapper = mapper;
        }
        [HttpGet("getallTrail")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(List<TrailDTO>))]
        public IActionResult GetAllTrail()
        {
            var objList = trailRepo.GetTrails();

            var objDTO = new List<TrailDTO>();

            foreach (var obj in objList)
            {
                objDTO.Add(mapper.Map<TrailDTO>(obj));
            }
            return Ok(objDTO);
        }

        [HttpGet("getTrailbyid/{Trailid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(TrailDTO))]
        public IActionResult GetTrailById(int Trailid)
        {
            var obj = trailRepo.GetTrail(Trailid);
            if (obj == null)
                return NotFound("Element Not Found");
            var objdto = mapper.Map<TrailDTO>(obj);
            return Ok(objdto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost("createTrail")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateTrail(TrailInsertDTO ndto)
        {
            if (ndto == null)
            {
                return BadRequest(ModelState);
            }

            if (trailRepo.TrailExists(ndto.Name))
            {
                ModelState.AddModelError("", "National Park Exists");
                return NotFound(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Trailobj = mapper.Map<Trail>(ndto);

            if (!trailRepo.CreateTrail(Trailobj))
            {
                ModelState.AddModelError("", $"Something went Wrong when saving the record {ndto.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetTrailById",new { Trailid =Trailobj.Id},Trailobj);
            ;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPatch("updateTrail/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateTrail(int id, [FromBody] TrailUpdateDTO ndto)
        {
            if (ndto == null || id != ndto.Id)
            {
                return BadRequest(ModelState);
            }
            var Trailobj = mapper.Map<Trail>(ndto);
            if (!trailRepo.UpdateTrail(Trailobj))
            {
                ModelState.AddModelError("", $"Something went Wrong when updating the record {ndto.Name}");
                return StatusCode(500, ModelState);
            }

            //return CreatedAtAction("");
            //return Ok("Updated");
            return StatusCode(200, "Updated");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("deleteTrail/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteTrail(int id)
        {
            if (!trailRepo.TrailExists(id))
                return NotFound("Element Not Present");

            var Trailobj = trailRepo.GetTrail(id);
            if (!trailRepo.DeleteTrail(Trailobj))
            {
                ModelState.AddModelError("", $"Something went Wrong when deleting the record {Trailobj.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Deleted");
        }
    }
}
