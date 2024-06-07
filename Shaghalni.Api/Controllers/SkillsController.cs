using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core.DTOs.Companies;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core;
using Shaghalni.Core.DTOs;
using Shaghalni.Core.Models;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SkillsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkillsAsync()
        {
            return Ok(await _unitOfWork.Skills.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _unitOfWork.Skills.FindAsync(c => c.Id == id);

            if (skill is null)
                return NotFound();

            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkillAsync(SkillDTO model)
        {
            var newSkill = _mapper.Map<Skill>(model);

            await _unitOfWork.Skills.AddAsync(newSkill);

            await _unitOfWork.Complete();

            return Ok(newSkill);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSkillAsync(int id, SkillDTO model)
        {
            var skill = await _unitOfWork.Skills.FindAsync(a => a.Id == id);

            if (skill is null)
                return NotFound();

            _mapper.Map(model, skill);

            _unitOfWork.Skills.Update(skill);

            await _unitOfWork.Complete();

            return Ok(skill);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSkillAsync(int id)
        {
            var skill = _unitOfWork.Skills.Delete(id);

            if (skill is null)
                return NotFound();

            await _unitOfWork.Complete();

            return Ok(skill);
        }
    }
}
