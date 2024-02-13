// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Net;
// using System.Threading.Tasks;
// using Application.Core;
// using Application.Dtos.Orders;
// using Application.Dtos.Products;
// using AutoMapper;
// using Domain.Entities;
// using FluentValidation;
// using Infrastructures.Context;
// using Infrastructures.Data.UnitOfWorks;
// using MediatR;
// using Microsoft.EntityFrameworkCore;

// namespace Application.Orders
// {
//     public class Create
//     {
//         public class Command : IRequest<Result<OrderDto>>
//         {
//             public int UserId { get; set; }

//             public int[] ProductIds { get; set; }
//         }

//         public class Handler : IRequestHandler<Command, Result<OrderDto>>
//         {
//             private readonly IUnitOfWork _unitOfWork;
//             private readonly IMapper _mapper;
//             private readonly IValidator<Command> _createCommandValidator;

//             public Handler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Command> createCommandValidator)
//             {
//                 _createCommandValidator = createCommandValidator;
//                 _unitOfWork = unitOfWork;
//                 _mapper = mapper;
//             }

//             public async Task<Result<OrderDto>> Handle(Command request, CancellationToken cancellationToken)
//             {
//                 var validationResult = _createCommandValidator.Validate(request);
//                 if (!validationResult.IsValid)
//                 {
//                     return Result<OrderDto>.Failure(validationResult.Errors[0].ErrorMessage);
//                 }
//                 var order = new Order { UserId = request.UserId };
//                 var products = await _unitOfWork.ProductRepository.GetAllAsync(request.ProductIds);
//                 order.OrderDetail = new OrderDetail() { DateTime = new(), Products = products };
//                 await _unitOfWork.OrderRepository.AddAsync(order);
//                 if (await _unitOfWork.SaveChangesAsync() > 0)
//                 {
//                     var orderDto = _mapper.Map<OrderDto>(order);
//                     return Result<OrderDto>.Success(orderDto);
//                 }
//                 else
//                 {
//                     return Result<OrderDto>.Failure("عملیات با خطا مواجه شد.");
//                 }
//             }
//         }
//     }
// }

