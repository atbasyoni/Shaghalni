using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core;
using Shaghalni.Core.DTOs.Companies;
using Shaghalni.Core.Models.Companies;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompaniesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> AddCompanyAsync(CompanyDTO model)
        {
            var newCompany = _mapper.Map<Company>(model);

            await _unitOfWork.Companies.AddAsync(newCompany);

            await _unitOfWork.Complete();

            return Ok(newCompany);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompanyAsync(int id, CompanyDTO model)
        {
            var company = await _unitOfWork.Companies.FindAsync(a => a.Id == id);
            
            if (company is null)
                return NotFound();

            _mapper.Map(model, company);

            _unitOfWork.Companies.Update(company);

            await _unitOfWork.Complete();
            
            return Ok(company);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            var company = _unitOfWork.Companies.Delete(id);

            if (company is null)
                return NotFound();

            await _unitOfWork.Complete();

            return Ok(company);
        }
    }
}
