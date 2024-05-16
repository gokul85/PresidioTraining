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

    }
}
