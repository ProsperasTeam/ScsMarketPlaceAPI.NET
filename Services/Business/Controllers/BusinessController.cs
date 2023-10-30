using Business.BusinessLogic.Contracts.Repositories;
using Business.Common;
using Microsoft.AspNetCore.Mvc;
using ba = Business.DataAccess.Entities;

namespace Business.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusinessController : ControllerBase
{
    public IBusinessRepository BusinessRepository { get; }

    public BusinessController(IBusinessRepository businessRepository)
    {
        BusinessRepository = businessRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var business= await BusinessRepository.ListAllAsync();
        if (!business.Any())
            return NotFound();
        return Ok(business);
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var userById = await BusinessRepository.GetByIdAsync(id);
        if(userById is null)
            return NotFound();

        return Ok(userById);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ba.Business bussine)
    {
        await BusinessRepository.AddAsync(bussine);
        return Ok(bussine);
    }

    [HttpPut]
    public async Task<IActionResult> Update(ba.Business bussine)
    {
        var userById = await BusinessRepository.GetByIdAsync(bussine.Id);
        if (userById is null)
            return NotFound();

        await BusinessRepository.UpdateAsync(bussine);
        return Ok(bussine);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ba.Business bussine)
    {
        var userById = await BusinessRepository.GetByIdAsync(bussine.Id);
        if (userById is null)
            return NotFound();

        await BusinessRepository.DeleteAsync(bussine);
        return Ok(bussine);
    }
}
