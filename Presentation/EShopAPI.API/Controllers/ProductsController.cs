using EShopAPI.Application.Repositories;
using EShopAPI.Application.ViewModels.Products;
using EShopAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShopAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
            //    new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
            //    new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30 },
            //});
            //await _productWriteRepository.SaveAsync();

            //Product product = await _productReadRepository.GetByIdAsync("8072a927-59ef-4cb2-b85e-574e2e2c63df", false);
            //product.Name = "Phone";
            //await _productWriteRepository.SaveAsync();

            //var customerId = new Guid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Ayxan" });
            //_customerWriteRepository.SaveAsync();
            //await _orderWriteRepository.AddAsync(new() { Description = "something", Address = "Baku", CustomerId = Guid.Parse("389963e9-0dbf-4b29-9dd4-d283f87e841d") });
            //await _orderWriteRepository.AddAsync(new() { Description = "something 2", Address = "Sumgait", CustomerId = Guid.Parse("389963e9-0dbf-4b29-9dd4-d283f87e841d") });
            //_orderWriteRepository.SaveAsync();

            //Order order = await _orderReadRepository.GetByIdAsync("bb3e3089-8de0-4c5a-959f-09635c7c5cfb");
            //order.Address = "Yasamal";
            //await _orderWriteRepository.SaveAsync();
            //return Ok();


            return Ok(_productReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
