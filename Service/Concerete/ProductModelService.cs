using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository;
using Core.Services.Response;
using Entities;
using Models.Concerete.Product;
using Service.Abstract;

namespace Service.Concerete
{
    public class ProductModelService : IProductService<ProductModel>
    {
        private readonly IRepository<Product> _repository;

        public ProductModelService(IRepository<Product> repository)
        {
            this._repository = repository;
        }

        public ServiceResponse<bool> Delete(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ProductModel> FindById(int id)
        {
            var response = new ServiceResponse<ProductModel>(null);
            var product = _repository.GetById(id);

            response.Count = 1;


            var productViewModel = new ProductModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                InnerBarcode = product.InnerBarcode,
                Name = product.Name,
                IsDeleted = product.IsDeleted,
                Price = product.Price,
                Stock = product.Stock
            };

            response.Entity = productViewModel;

            return response;
        }

        public async Task<ServiceResponse<ProductModel>> FindByIdAsync(int id)
        {
            var response=new ServiceResponse<ProductModel>(null);
            var query = await _repository.Find(p => p.Id == id);

            response.Count = query.Count();

            var product = query.FirstOrDefault();

            var productViewModel = new ProductModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                InnerBarcode = product.InnerBarcode,
                Name = product.Name,
                IsDeleted = product.IsDeleted,
                Price = product.Price,
                Stock = product.Stock
            };

            response.Entity = productViewModel;

            return response;
        }

        
        public ServiceResponse<int> Insert(ProductModel model)
        {
            var response=new ServiceResponse<int>(null);
            var query = _repository.Insert(new Product()
            {
                CategoryId = model.CategoryId,
                InnerBarcode = model.InnerBarcode,
                Name = model.Name,
                IsDeleted = model.IsDeleted,
                Price = model.Price,
                Stock = model.Stock

            });

            response.Count = 1;
            response.Entity = query.Id;

            return response;
        }

        public ServiceResponse<ProductModel> List()
        {
            var response=new ServiceResponse<ProductModel>(null);
            var query = _repository.GetAll();

            response.Count = query.Count;

            var list = query.ToList();

            foreach (var product in list)
            {
                var productViewModel = new ProductModel()
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    InnerBarcode = product.InnerBarcode,
                    IsDeleted = product.IsDeleted,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };

                response.List.Add(productViewModel);
            }

            return response;
        }

        public async Task<ServiceResponse<ProductModel>> ListAsync()
        {
            var response = new ServiceResponse<ProductModel>(null);
            var query = await _repository.GetAllAsync();

            response.Count = query.Count;

            var list = query.ToList();

            foreach (var product in list)
            {
                var productViewModel = new ProductModel()
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    InnerBarcode = product.InnerBarcode,
                    IsDeleted = product.IsDeleted,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };

                response.List.Add(productViewModel);
            }

            return response;
        }

        public ServiceResponse<int> Update(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}