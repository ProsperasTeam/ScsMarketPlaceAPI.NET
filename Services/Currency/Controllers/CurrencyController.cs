using System;
using Microsoft.AspNetCore.Mvc;
using Currency.CurrencyLogic.Contracts.Repositories;
using cu = Currency.DataAccess.Entities;


namespace Currency.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        public ICurrencyRepository CurrencyRepository { get; }

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            CurrencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var currency = await CurrencyRepository.ListAllAsync();
            if (!currency.Any())
                return NotFound();
            return Ok(currency);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var userById = await CurrencyRepository.GetByIdAsync(id);
            if (userById is null)
                return NotFound();

            return Ok(userById);
        }

        [HttpPost]
        public async Task<IActionResult> Create(cu.Currency bussine)
        {
            await CurrencyRepository.AddAsync(bussine);
            return Ok(bussine);
        }

        [HttpPut]
        public async Task<IActionResult> Update(cu.Currency currency)
        {
            var userById = await CurrencyRepository.GetByIdAsync(currency.Id);
            if (userById is null)
                return NotFound();

            await CurrencyRepository.UpdateAsync(currency);
            return Ok(currency);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(cu.Currency currency)
        {
            var userById = await CurrencyRepository.GetByIdAsync(currency.Id);
            if (userById is null)
                return NotFound();

            await CurrencyRepository.DeleteAsync(currency);
            return Ok(currency);
        }
    }
}
