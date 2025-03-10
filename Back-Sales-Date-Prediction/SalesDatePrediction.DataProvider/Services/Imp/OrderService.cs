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
    public class OrderService : IService<OrderDto>
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var orders = await this.repository.GetAll();
            return this.mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetById(int id)
        {
            var order = await this.repository.GetById(id);
            return this.mapper.Map<OrderDto>(order);
        }

        public async Task Add(OrderDto orderDTO)
        {
            var order = this.mapper.Map<Order>(orderDTO);
            await this.repository.Add(order);
        }

        public async Task Update(OrderDto orderDTO)
        {
            var order = this.mapper.Map<Order>(orderDTO);
            await this.repository.Update(order);
        }

        public async Task Delete(int id)
        {
            await this.repository.Delete(id);
        }
    }
}
