using AutoMapper;
using SalesDatePrediction.DataProvider.Dtos;
using SalesDatePrediction.Repository.Models;

namespace SalesDatePrediction.DataProvider.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Shipper, ShipperDto>();
            CreateMap<CustomerOrderPrediction, CustomerOrderPredictionDto>();
        }
    }
}
