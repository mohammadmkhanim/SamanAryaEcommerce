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
    public class Create
    {
        public class Command : IRequest<Result<UserDto>>
        {
            public string Username { get; set; }

            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<UserDto>>
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

            public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationResult = _createCommandValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<UserDto>.Failure(validationResult.Errors[0].ErrorMessage);
                }
                if (await _unitOfWork.UserRepository.ExistUsernameAsync(request.Username))
                {
                    return Result<UserDto>.Failure("کاربر از قبل وجود دارد.");
                }
                var user = _mapper.Map<User>(request);
                user.Password = HashService.GenerateSha256Hash(user.Password);
                await _unitOfWork.UserRepository.AddAsync(user);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    var userDto = _mapper.Map<UserDto>(user);
                    return Result<UserDto>.Success(userDto);
                }
                else
                {
                    return Result<UserDto>.Failure("عملیات با خطا مواجه شد.");
                }
            }
        }
    }
}

