using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shaghalni.Core.DTOs.Companies;
using Shaghalni.Core.Models.Companies;
using Shaghalni.Core;
using Shaghalni.Core.DTOs.Employees;
using Shaghalni.Core.Models.Employees;

namespace Shaghalni.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            return Ok(await _unitOfWork.Employees.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _unitOfWork.Employees.FindAsync(c => c.Id == id);

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeDTO model)
        {
            var newEmployee = _mapper.Map<Employee>(model);

            await _unitOfWork.Employees.AddAsync(newEmployee);

            await _unitOfWork.Complete();

            return Ok(newEmployee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, EmployeeDTO model)
        {
            var employee = await _unitOfWork.Employees.FindAsync(a => a.Id == id);

            if (employee is null)
                return NotFound();

            _mapper.Map(model, employee);

            _unitOfWork.Employees.Update(employee);

            await _unitOfWork.Complete();

            return Ok(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var employee = _unitOfWork.Employees.Delete(id);

            if (employee is null)
                return NotFound();

            await _unitOfWork.Complete();

            return Ok(employee);
        }
    }
}
