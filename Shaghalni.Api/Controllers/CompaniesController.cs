using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            return Ok(await _unitOfWork.Companies.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _unitOfWork.Companies.FindAsync(c => c.Id == id);

            if(company is null)
                return NotFound();

            return Ok(company);
        }
    }
}
