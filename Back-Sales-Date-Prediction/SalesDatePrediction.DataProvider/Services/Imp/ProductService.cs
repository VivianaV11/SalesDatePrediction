using AutoMapper;
using SalesDatePrediction.DataProvider.Dtos;
using SalesDatePrediction.Repository.Models;
using SalesDatePrediction.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.DataProvider.Services.Imp
{
    public class ProductService : IService<ProductDto>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await this.repository.GetAll();
            return this.mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await this.repository.GetById(id);
            return this.mapper.Map<ProductDto>(product);
        }

        public async Task Add(ProductDto productDTO)
        {
            var product = this.mapper.Map<Product>(productDTO);
            await this.repository.Add(product);
        }

        public async Task Update(ProductDto productDTO)
        {
            var product = this.mapper.Map<Product>(productDTO);
            await this.repository.Update(product);
        }

        public async Task Delete(int id)
        {
            await this.repository.Delete(id);
        }
    }
}
