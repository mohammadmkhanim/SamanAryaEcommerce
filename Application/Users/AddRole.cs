using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.Products;
using Application.Dtos.Users;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures.Context;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class AddRole
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Name { get; set; }
            public int UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var role = await _unitOfWork.RoleRepository.GetByNameAsync(request.Name);
                var userRole = new UserRole() { UserId = request.UserId, RoleId = role.Id };
                await _unitOfWork.UserRoleRepository.AddAsync(userRole);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    return Result<Unit>.Success(Unit.Value);
                }
                else
                {
                    return Result<Unit>.Failure("عملیات با خطا مواجه شد.");
                }
            }
        }
    }
}

