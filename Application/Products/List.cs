using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.Products;
using AutoMapper;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products
{
    public class List
    {
        public class Query : IRequest<Result<List<ProductDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<ProductDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<List<ProductDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync();
                var productDtos = _mapper.Map<List<ProductDto>>(products);
                return Result<List<ProductDto>>.Success(productDtos);
            }
        }
    }
}