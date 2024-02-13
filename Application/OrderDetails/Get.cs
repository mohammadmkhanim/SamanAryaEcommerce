using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.OrderDetails;
using Application.Dtos.Products;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures.Context;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrderDetails
{
    public class Get
    {
        public class Query : IRequest<Result<OrderDetailDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<OrderDetailDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<OrderDetailDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var orderDetail = await _unitOfWork.OrderDetailsRepository.GetByIdAsync(request.Id);
                if (orderDetail == null)
                {
                    return Result<OrderDetailDto>.Failure("جزعیات سفارش وجود ندارد.");
                }
                var orderDetailDto = _mapper.Map<OrderDetailDto>(orderDetail);
                return Result<OrderDetailDto>.Success(orderDetailDto);
            }
        }
    }
}

