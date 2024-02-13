using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.Orders;
using Application.Dtos.Products;
using AutoMapper;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders
{
    public class List
    {
        public class Query : IRequest<Result<List<OrderDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<OrderDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<List<OrderDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _unitOfWork.OrderRepository.GetAllAsync();
                var productDtos = _mapper.Map<List<OrderDto>>(products);
                return Result<List<OrderDto>>.Success(productDtos);
            }
        }
    }
}