using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.CustomActionFilters;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _dbContext;

        private readonly IRegionRepository _regionRepository;

        private readonly IMapper _mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: api/Regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            // Get all regions from the database

            var regions = await _regionRepository.GetAllAsync();

            // Using AutoMapper
            var regionDtos = _mapper.Map<List<RegionDto>>(regions);

            return Ok(regionDtos);
        }

        // GET REGION BY ID
        // GET: api/Regions/5
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            //  Map the region to the RegionDto model
            var regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }


        // CREATE REGION
        // POST: api/Regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            // Map the AddRegionRequestDto to the Region model
            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);

            regionDomainModel = await _regionRepository.AddAsync(regionDomainModel);


            //  Map the region to the RegionDto model
            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);


            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
        }


        // UPDATE REGION
        // PUT: api/Regions/5
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            // Map the UpdateRegionRequestDto to the Region model
            var region = _mapper.Map<Region>(updateRegionRequestDto);

            region = await _regionRepository.UpdateAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            //  Map the region to the RegionDto model
            var regionDto = _mapper.Map<RegionDto>(region);

            return Ok(regionDto);

        }

        // DELETE REGION
        // DELETE: api/Regions/5
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();

            }


            return Ok();

        }

    }



}
