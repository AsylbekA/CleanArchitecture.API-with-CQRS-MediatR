using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CleanArhcitecture.Application.Features.ProductFetures.Queries;
using CleanArhcitecture.Application.Features.ProductFetures.Commands;

namespace CleanArchitecture.API.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private IMediator _mediatR;
        public ProductController(IMediator mediator) => _mediatR = mediator ?? throw new ArgumentNullException(nameof(mediator));


        /// <summary>
        /// Creates Product
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductCommand command)
        {
            return Ok(await _mediatR.Send(command));
        }

        /// <summary>
        /// Gets Product by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetProductById(int Id)
        {
            return Ok(await _mediatR.Send(new GetProductByIdQuery { Id = Id }));
        }


    }
}
