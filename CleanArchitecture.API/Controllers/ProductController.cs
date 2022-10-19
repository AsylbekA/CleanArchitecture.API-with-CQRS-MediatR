using CleanArhcitecture.Application.Features.ProductFetures.Commands;
using CleanArhcitecture.Application.Features.ProductFetures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<ActionResult> GetAllProducts()
        //{
        //    return Ok(await _mediatR.Send(new GetAllProductsQuery()));
        //}

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

        /// <summary>
        /// Deletes Product by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            return Ok(await _mediatR.Send(new DeleteProductCommand { Id = Id }));
        }

        /// <summary>
        /// Updates Products by id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateProduct(int Id, UpdateProductCommand command)
        {
            if (Id != command.Id) return BadRequest();
            return Ok(await _mediatR.Send(command));
        }
    }
}
