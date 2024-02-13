using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.Products;
using Application.Dtos.Roles;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures.Context;
using Infrastructures.Data.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Roles
{
    public class SeedRoles
    {
        public class Command : IRequest<Result<Unit>>
        {
            public List<string> Names { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
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

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationResult = _createCommandValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<Unit>.Failure(validationResult.Errors[0].ErrorMessage);
                }
                foreach (var name in request.Names)
                {
                    await _unitOfWork.RoleRepository.AddAsync(new() { Name = name });
                }
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

