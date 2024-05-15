using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;
using PizzaHutAPI.Models.DTOs;
using System.Numerics;

namespace PizzaHutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaHutServices _PizzaHutServices;
        public PizzaController(IPizzaHutServices PizzaHutServices)
        {
            _PizzaHutServices = PizzaHutServices;
        }

        [HttpGet("GetAllPizzas")]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IList<Pizza>>> GetAllPizzas()
        {
            try
            {
                var pizzas = await _PizzaHutServices.GetAllPizza();
                return Ok(pizzas.ToList());
            }
            catch (NoPizzaFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("GetPizzaByName")]
        [HttpPost]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> Get([FromBody] string name)
        {
            try
            {
                var pizzas = await _PizzaHutServices.GetPizzaByName(name);
                return Ok(pizzas);
            }
            catch (NoPizzaFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("DeletePizzaById")]
        [HttpDelete]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> Delete([FromBody] int id)
        {
            try
            {
                var pizzas = await _PizzaHutServices.DeletePizzaById(id);
                return Ok(pizzas);
            }
            catch (NoPizzaFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("UpdatePizzaPrice")]
        [HttpPut]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> UpdatePizzaPrice([FromBody] UpdatePizzaPriceDTO updatePizzaPriceDTO)
        {
            try
            {
                var pizza = await _PizzaHutServices.GetPizzaById(updatePizzaPriceDTO.Id);
                pizza.Price=updatePizzaPriceDTO.Price;
                var UpdatedPizza = await _PizzaHutServices.UpdatePizza(pizza);
                return Ok(UpdatedPizza);
            }
            catch (NoPizzaFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("UpdatePizzaStock")]
        [HttpPut]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pizza>> UpdatePizzaStock([FromBody] UpdatePizzaStockDTO updatePizzStockDTO)
        {
            try
            {
                var pizza = await _PizzaHutServices.GetPizzaById(updatePizzStockDTO.Id);
                pizza.Stocks = updatePizzStockDTO.Stocks;
                var UpdatedPizza = await _PizzaHutServices.UpdatePizza(pizza);
                return Ok(UpdatedPizza);
            }
            catch (NoPizzaFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }


    }
}
