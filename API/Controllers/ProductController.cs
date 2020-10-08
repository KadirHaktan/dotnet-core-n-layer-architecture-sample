using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Response;
using Microsoft.AspNetCore.Http;
using Models.Concerete.Product;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService<ProductModel> _productService;

        public ProductController(IProductService<ProductModel> productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public ServiceResponse<ProductModel> GetProducts()
        {
            var response=new ServiceResponse<ProductModel>(HttpContext);

            response.List = _productService.List().List.ToList();
            response.IsSuccesful = true;
            response.Count = response.List.Count;

            return response;
        }

        [HttpPost]
        public ServiceResponse<int> AddProduct(ProductModel model)
        {
            var response = new ServiceResponse<int>(HttpContext);

            var query = _productService.Insert(model);

            response.IsSuccesful = true;
            response.Count = query.Count;
            response.Id = query.Id;

            return response;
        }

    }
}