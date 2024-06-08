using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core.DTOs.Companies;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core;
using Shaghalni.Core.DTOs.Applications;
using Shaghalni.Core.Models.Applications;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplicationsAsync()
        {
            return Ok(await _unitOfWork.Applications.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var application = await _unitOfWork.Applications.FindAsync(c => c.Id == id);

            if (application is null)
                return NotFound();

            return Ok(application);
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicationAsync(ApplicationDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newApplication = _mapper.Map<Application>(model);

            await _unitOfWork.Applications.AddAsync(newApplication);

            await _unitOfWork.Complete();

            return CreatedAtAction("AddApplication", new { Id = newApplication.Id });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplicationAsync(int id, ApplicationDTO model)
        {
            var application = await _unitOfWork.Applications.FindAsync(a => a.Id == id);

            if (application is null)
                return NotFound();

            _mapper.Map(model, application);

            _unitOfWork.Applications.Update(application);

            await _unitOfWork.Complete();

            return Ok(application);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplicationAsync(int id)
        {
            var application = _unitOfWork.Applications.Delete(id);

            if (application is null)
                return NotFound();

            await _unitOfWork.Complete();

            return Ok(application);
        }
    }
}
