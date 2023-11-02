using Lenders.LendersLogic.Contracts.Repositories;
using Lenders.Common;
using Microsoft.AspNetCore.Mvc;
using Lenders.DataAccess.Entities;

namespace Lenders.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LendersController : ControllerBase
{
    public ILendersRepository LendersRepository { get; }

    public LendersController(ILendersRepository lendersRepository)
    {
        LendersRepository = lendersRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var Lenders= await LendersRepository.ListAllAsync();
        if (!Lenders.Any())
            return NotFound();
        return Ok(Lenders);
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var userById = await LendersRepository.GetByIdAsync(id);
        if(userById is null)
            return NotFound();

        return Ok(userById);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Lender lender)
    {
        await LendersRepository.AddAsync(lender);
        return Ok(lender);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Lender lender)
    {
        var userById = await LendersRepository.GetByIdAsync(lender.Id);
        if (userById is null)
            return NotFound();

        await LendersRepository.UpdateAsync(lender);
        return Ok(lender);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Lender lender)
    {
        var userById = await LendersRepository.GetByIdAsync(lender.Id);
        if (userById is null)
            return NotFound();

        await LendersRepository.DeleteAsync(lender);
        return Ok(lender);
    }
}
