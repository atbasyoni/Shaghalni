using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core;
using Shaghalni.Core.DTOs.Companies;
using Shaghalni.Core.DTOs.Jobs;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core.Models.Jobs;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobDetailsById(int id)
        {
            var jobDetails = await _unitOfWork.JobDetails.FindAsync(jd => jd.JobId == id, new[] { "Job", "SalaryRate", "CareerLevel", "EducationLevel", "JobCategory" });

            if (jobDetails is null)
                return NotFound();

            var jobDetailsDTO = _mapper.Map<JobDetailsDTO>(jobDetails);

            return Ok(jobDetailsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(JobDetailsDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newJobDetails = _mapper.Map<JobDetails>(model);

            await _unitOfWork.JobDetails.AddAsync(newJobDetails);

            await _unitOfWork.Complete();

            return Ok(newJobDetails);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobDetailsAsync(int id, JobDetailsDTO model)
        {
            var jobDetails = await _unitOfWork.JobDetails.FindAsync(a => a.Id == id);

            if (jobDetails is null)
                return NotFound();

            _mapper.Map(model, jobDetails);

            _unitOfWork.JobDetails.Update(jobDetails);

            await _unitOfWork.Complete();

            return Ok(jobDetails);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var jobDetails = _unitOfWork.JobDetails.Delete(id);

            if (jobDetails is null)
                return NotFound();

            await _unitOfWork.Complete();

            return Ok(jobDetails);
        }
    }
}
