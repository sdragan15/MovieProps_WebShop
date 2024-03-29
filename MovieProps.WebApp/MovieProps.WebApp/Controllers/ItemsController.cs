﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProps.BLL.Contract.DTOs.Item;
using MovieProps.BLL.Contract.DTOs.Order;
using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.UnitOfWork;

namespace MovieProps.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _itemService.GetAll());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] ItemDataIn dataIn)
        {
            return Ok(await _itemService.Add(dataIn));
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            return Ok(await _itemService.DeleteUser(id));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateItem([FromForm] ItemDataIn dataIn)
        {
            return Ok(await _itemService.UpdateItem(dataIn));
        }

        [HttpPost("getItemsByIds")]
        public async Task<IActionResult> GetItemsByIds([FromBody] OrderDataIn dataIn)
        {
            return Ok(await _itemService.GetItemsByIds(dataIn.Items));
        }
    }
}
