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
    public class Edit
    {
        public class Command : IRequest<Result<ProductDto>>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public double Price { get; set; }

            public string? ImageName { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<ProductDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IValidator<Command> _createCommandValidator;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Command> createCommandValidator)
            {
                _createCommandValidator = createCommandValidator;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<ProductDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationResult = _createCommandValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<ProductDto>.Failure(validationResult.Errors[0].ErrorMessage);
                }
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
                if (product == null)
                {
                    return Result<ProductDto>.Failure("محصول وحود ندارد.");
                }
                var updateProduct = _mapper.Map<Product>(request);
                if (request.ImageName == null)
                {
                    updateProduct.ImageName = product.ImageName;
                }
                _unitOfWork.ProductRepository.Update(updateProduct);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    var productDto = _mapper.Map<ProductDto>(updateProduct);
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

