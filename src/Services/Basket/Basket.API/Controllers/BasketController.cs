﻿using Basket.API.Repositories;
using Basket.API.Entities;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController
    {

        private readonly IBasketRepository _repository;
        private readonly ILogger _logger;
        public BasketController(IBasketRepository repository, ILogger<BasketController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("{userName}", Name ="GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);
            return new OkObjectResult(basket ?? new ShoppingCart(userName));
        }


        [HttpPut(Name = "UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart cart)
        {
            return new OkObjectResult(await _repository.UpdateBasket(cart));
        }


        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return new OkObjectResult(null);
        }
    }
}
