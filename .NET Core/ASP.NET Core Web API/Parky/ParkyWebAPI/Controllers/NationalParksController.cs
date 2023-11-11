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
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class NationalParksController : ControllerBase
    {
        private INationalParkRepository nRepo;
        private IMapper mapper;

        public NationalParksController(INationalParkRepository nRepo, IMapper mapper)
        {
            this.nRepo = nRepo;
            this.mapper = mapper;
        }

        [HttpGet("getallnationalpark")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(List<NationalParkDTO>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetAllNationalPark()
        {
            var objList = nRepo.GetNationalParks();

            var objDTO = new List<NationalParkDTO>();

            foreach(var obj in objList)
            {
                objDTO.Add(mapper.Map<NationalParkDTO>(obj));
            }
            return Ok(objDTO);
        }

        
        [HttpGet("getnationalparkbyid/{nationalparkid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NationalParkDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetNationalParkById(int nationalparkid)
        {
            var obj = nRepo.GetNationalPark(nationalparkid);
            if (obj == null)
                return NotFound("Element Not Found");
            var objdto = mapper.Map<NationalParkDTO>(obj);
            return Ok(objdto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost("createnationalPark")]
        [ProducesResponseType(StatusCodes.Status201Created,Type=typeof(NationalPark))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateNationalPark(NationalParkDTO ndto)
        {
            if(ndto==null)
            {
                return BadRequest(ModelState);
            }

            if(nRepo.NationalParkExists(ndto.Name))
            {
                ModelState.AddModelError("", "National Park Exists");
                return NotFound(ModelState);
            }

            var nationalParkobj = mapper.Map<NationalPark>(ndto);

            if(!nRepo.CreateNationalPark(nationalParkobj))
            {
                ModelState.AddModelError("", $"Something went Wrong when saving the record {ndto.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetNationalParkById",new { nationalparkid = nationalParkobj.Id},nationalParkobj);
            //return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPatch("updatenationalpark/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult UpdateNationalPark(int id,[FromBody]NationalParkDTO ndto)
        {
            if(ndto==null || id!=ndto.Id)
            {
                return BadRequest(ModelState);
            }
            var nationalParkobj = mapper.Map<NationalPark>(ndto);
            if (!nRepo.UpdateNationalPark(nationalParkobj))
            {
                ModelState.AddModelError("", $"Something went Wrong when updating the record {ndto.Name}");
                return StatusCode(500, ModelState);
            }

            //return NoContent();
            return Ok("Updated");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("deletenationalpark/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteNationalPark(int id)
        {
            if (!nRepo.NationalParkExists(id))
                return NotFound("Element Not Present");

            var nationalParkobj = nRepo.GetNationalPark(id);
            if(!nRepo.DeleteNationalPark(nationalParkobj))
            {
                ModelState.AddModelError("", $"Something went Wrong when deleting the record {nationalParkobj.Name}");
                return StatusCode(500, ModelState);
            }

            //return NoContent();
            return Ok("Deleted");
        }
    }
}
