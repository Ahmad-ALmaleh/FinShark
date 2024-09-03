﻿using FINSHARK.Data;
using FINSHARK.Dtos.Stock;
using FINSHARK.Interfaces;
using FINSHARK.Mappers;
using FINSHARK.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FINSHARK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        
        private readonly IStockRepository _stockRepo;
        public StockController( IStockRepository stockRepo)
        {
            
            _stockRepo = stockRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepo.GetAllAsync();
             var stockDto= stocks .Select(s=> s.ToStockDto());
            return Ok(stockDto);
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {
            var stock =await _stockRepo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task <IActionResult> Creat([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
           await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task <IActionResult> Update([FromRoute] int id , [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel =await _stockRepo.UpdateAsync(id , updateDto);
            if (stockModel == null)
            {
                return NotFound();
            }
            
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var stockModel =await _stockRepo.DeleteAsync(id);
            if(stockModel == null)
            {
                return NotFound();
            }
             
            return NoContent();
        }
    }
}
