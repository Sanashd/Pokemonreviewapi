﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewapp.Dto;
using PokemonReviewapp.Interfaces;
using PokemonReviewapp.Models;
using PokemonReviewapp.Repository;

namespace PokemonReviewapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners);

        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();

            var owner = _mapper.Map<PokemonDto>(_ownerRepository.GetOwner(ownerId));



            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owner);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonByOwer(int ownerId)

        {
            if (!_ownerRepository.OwnerExists(ownerId))

            {
                return NotFound();

            }

            var owner = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetOwner(ownerId));

            if (!ModelState.IsValid)

                return BadRequest(ModelState);  

                return Ok(owner);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateOwner([FromQuery] int countryId , [FromBody] OwnerDto ownerCreate)
        {
            if (ownerCreate == null)
                return BadRequest(ModelState);

            var owners = _ownerRepository.GetOwners().Where(c => c.LastName.Trim().ToUpper() == ownerCreate.LastName.TrimEnd().ToUpper()).FirstOrDefault();

            if (owners != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);

            }

            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var ownerMap = _mapper.Map<Owner>(ownerCreate);

            ownerMap.Country = _countryRepository.GetCountry(countryId);    


            if (!_ownerRepository.CreateOwner(ownerMap))
            {

                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);

            }

            return Ok("Successfully Created ");

        }


        [HttpPut("{ownerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdatedOwner(int ownerId, [FromBody] OwnerDto updatedOwner)
        {

            if (updatedOwner == null)
                return BadRequest(ModelState);


            if (ownerId != updatedOwner.Id)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();



            var ownerMap = _mapper.Map<Owner>(updatedOwner);

            if (!_ownerRepository.UpdateOwner(ownerMap))
            {

                ModelState.AddModelError("", "Something went wrong while updating owner");
                return StatusCode(500, ModelState);

            }

            return Ok("Successfully Updated");

        }

        [HttpDelete("{ownerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOwner(int ownerId)


        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var ownerToDelete = _ownerRepository.GetOwner(ownerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ownerRepository.DeleteOwner(ownerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return Ok("Successfully Deleted");
        }






    }


}
