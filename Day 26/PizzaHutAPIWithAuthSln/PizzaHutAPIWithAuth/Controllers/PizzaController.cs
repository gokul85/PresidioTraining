using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPIWithAuth.Exceptions;
using PizzaHutAPIWithAuth.Interfaces;
using PizzaHutAPIWithAuth.Models;

namespace PizzaHutAPIWithAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices pizzaServices;
        public PizzaController(IPizzaServices pizzaS)
        {
            pizzaServices = pizzaS;
        }
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Pizza>>> Get()
        {
            try
            {
                var pizzas = await pizzaServices.GetAllPizzaAsync();
                return Ok(pizzas.ToList());
            }
            catch (NoPizzasFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
    }
}
