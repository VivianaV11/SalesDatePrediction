using SalesDatePrediction.DataProvider.Dtos;
using SalesDatePrediction.Repository.Models;
using SalesDatePrediction.Repository.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.DataProvider.Services.Imp
{
    public class CustomService : ICustomService
    {
        private readonly ICustomRepository repository;
        private readonly IRepository<Order> orderRepository;
        private readonly IMapper mapper;

        public CustomService(ICustomRepository repository, IRepository<Order> orderRepository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int id)
        {
            var orders = await this.repository.GetOrdersByCustomerId(id);

            return this.mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<IEnumerable<CustomerOrderPredictionDto>> GetSalesDatePrediction()
        {
            var orders = await this.repository.GetSalesDatePrediction();
            return this.mapper.Map<IEnumerable<CustomerOrderPredictionDto>>(orders);
        }

        public async Task<bool> CustomerExists(int customerId)
        {
            return await this.repository.CustomerExists(customerId);
        }


        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = new Order
            {
                CustId = createOrderDto.CustId,
                EmpId = createOrderDto.EmpId,
                ShipperId = createOrderDto.ShipperId,
                ShipName = createOrderDto.ShipName,
                ShipAddress = createOrderDto.ShipAddress,
                ShipCity = createOrderDto.ShipCity,
                OrderDate = createOrderDto.OrderDate,
                RequiredDate = createOrderDto.RequiredDate,
                ShippedDate = createOrderDto.ShippedDate,
                Freight = createOrderDto.Freight,
                ShipCountry = createOrderDto.ShipCountry
            };

            var orderDetail = new OrderDetail
            {
                ProductId = createOrderDto.ProductId,
                UnitPrice = createOrderDto.UnitPrice,
                Qty = createOrderDto.Qty,
                Discount = createOrderDto.Discount
            };

            await this.repository.CreateOrderAsync(order, orderDetail);
        }
    }
}
