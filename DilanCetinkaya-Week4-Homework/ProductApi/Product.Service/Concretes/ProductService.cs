using AutoMapper;
using Product.Data.Abstracts;
using Product.Data.Dtos;
using Product.Domain.Entities;
using Product.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Service.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task AddAsync(ProductDto productDto)
        {
            var product = _mapper.Map<ProductEntity>(productDto);
            await _repository.AddAsync(product);
        }

        public async Task Delete(int id)
        {
          var product = await _repository.GetAsync(id);
            if (product is null)
                throw new ArgumentException("Id not found");
            await _repository.Delete(id);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDto>>(products);
            return productDto;
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product is null)
                throw new ArgumentException("Record is not found");
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task Update(ProductDto productDto, int id)
        {
            var product = await _repository.GetAsync(id);
            if (product is null)
                throw new ArgumentException("Record is not found");
            var updatedProduct = _mapper.Map<ProductEntity>(productDto);
            updatedProduct.Id = id;
            await _repository.Update(updatedProduct);

        }
    }
}
