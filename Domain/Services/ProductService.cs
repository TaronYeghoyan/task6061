using Domain.Aggregates.Specifications;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = unitOfWork.ProductRepository;
        }

        public async Task<IEnumerable<Product>> All(CancellationToken cancellationToken = default)
        {
            return await _productRepository.ListAllAsync(cancellationToken);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _productRepository.GetByIdAsync(id, cancellationToken);
            await _productRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _productRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<Product> GetByIdNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var spec = new GetByIdNoTracingSpec<Product>(id);
            return await _productRepository.FirstOrDefaultAsync(spec, cancellationToken);
        }

        public async Task<bool> Set(Product entity, CancellationToken cancellationToken = default)
        {
            await _productRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Product entity, CancellationToken cancellationToken = default)
        {
            await _productRepository.UpdateAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}