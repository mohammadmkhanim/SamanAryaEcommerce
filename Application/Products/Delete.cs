using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.Products;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures.Context;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products
{
    public class Delete
    {
        public class Command : IRequest<Result<ProductDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<ProductDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<ProductDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var deleteProduct = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
                if (deleteProduct == null)
                {
                    return Result<ProductDto>.Failure("محصول وحود ندارد.");
                }
                await _unitOfWork.ProductRepository.DeleteAsync(request.Id);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    var productDto = _mapper.Map<ProductDto>(deleteProduct);
                    return Result<ProductDto>.Success(productDto);
                }
                else
                {
                    return Result<ProductDto>.Failure("عملیات با خطا مواجه شد.");
                }
            }
        }
    }
}

