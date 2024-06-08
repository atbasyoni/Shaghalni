using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core;
using Shaghalni.Core.DTOs.Jobs;
using Shaghalni.Core.Models.Jobs;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobsAsync(
            [FromQuery] string search = null,
            [FromQuery] string sort = null,
            [FromQuery] int page = 1
            )
        {
            var result = await _unitOfWork.Jobs.FindAllAsync(null, ((page - 1) * 8), 8, null, "ASC", new[] { "Company", "City", "Country", "JobType" });

            if (result is null)
                return NotFound();

            var jobs = _mapper.Map<List<JobDTO>>(result.Item1);
            var pages = result.Item2;

            return Ok(new { jobs, pages });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _unitOfWork.Jobs.FindAsync(c => c.Id == id, new[] { "Company", "City", "Country", "JobType" });

            if (job is null)
                return NotFound();

            var jobDTO = _mapper.Map<JobDTO>(job);
            return Ok(jobDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddJobAsync(JobDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newJob = _mapper.Map<Job>(model);

            await _unitOfWork.Jobs.AddAsync(newJob);

            await _unitOfWork.Complete();

            return Ok(newJob);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobAsync(int id, JobDTO model)
        {
            var job = await _unitOfWork.Jobs.FindAsync(a => a.Id == id);

            if (job is null)
                return NotFound();

            _mapper.Map(model, job);

            _unitOfWork.Jobs.Update(job);

            await _unitOfWork.Complete();

            return Ok(job);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJobAsync(int id)
        {
            var job = _unitOfWork.Jobs.Delete(id);

            if (job is null)
                return NotFound();

            await _unitOfWork.Complete();

            return Ok(job);
        }
    }
}
