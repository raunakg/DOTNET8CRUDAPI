using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this._mapper = mapper;
            this._walkRepository = walkRepository;
        }

        // Create a new walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map the AddWalkRequestDto to a Walk entity
            var walk = _mapper.Map<Walk>(addWalkRequestDto);

            // Create the walk
            var createdWalk = await _walkRepository.CreateWalkAsync(walk);

            // Map the created walk to a WalkDto
            var walkDto = _mapper.Map<WalkDto>(createdWalk);

            // Return the created walk
            return Ok(walkDto);

        }


        // Get all walks
        // GET: /api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get all walks
            var walks = await _walkRepository.GetAllAsync();

            // Map the walks to WalkDtos
            var walkDtos = _mapper.Map<IEnumerable<WalkDto>>(walks);

            // Return the walks
            return Ok(walkDtos);
        }

        // Get a walk by id
        // GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get the walk by id
            var walk = await _walkRepository.GetByIdAsync(id);

            // If the walk is not found, return a 404 Not Found
            if (walk == null)
            {
                return NotFound();
            }

            // Map the walk to a WalkDto
            var walkDto = _mapper.Map<WalkDto>(walk);

            // Return the walk
            return Ok(walkDto);
        }

        // Update a walk
        // PUT: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walk = _mapper.Map<Walk>(updateWalkRequestDto);

            var updatedWalk = await _walkRepository.UpdateAsync(id, walk);

            if (updatedWalk == null)
            {
                return NotFound();
            }

            var walkDto = _mapper.Map<WalkDto>(updatedWalk);

            return Ok(walkDto);
        }

        // Delete a walk
        // DELETE: /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walk = await _walkRepository.DeleteAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            var walkDto = _mapper.Map<WalkDto>(walk);

            return Ok(walkDto);

        }

    }
}
