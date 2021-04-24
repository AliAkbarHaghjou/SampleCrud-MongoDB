using SimpleCrud.Application.Repositories;
using SimpleCrud.Application.Services;
using SimpleCrud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitofwork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitofwork;
        }

        public async Task CreateProduct(Product Entity)
        {
            _productRepository.Add(Entity);
            await _unitOfWork.Commit();
        }

        public async Task UpdateProduct(Product Entity)
        {
            _productRepository.Update(Entity);
            await _unitOfWork.Commit();
        }

        public async Task DeleteProduct(string ProductID)
        {
            _productRepository.Remove(ProductID);
            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async ValueTask<Product> GetProductByID(string ProductID)
        {
            var result = await _productRepository.GetById(ProductID);
            return result;
        }
    }
}
