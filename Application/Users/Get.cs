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
    public class Get
    {
        public class Query : IRequest<Result<UserDto>>
        {
            public string Username { get; set; }

            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<UserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IValidator<Query> _createCommandValidator;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Query> createCommandValidator)
            {
                _createCommandValidator = createCommandValidator;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var validationResult = _createCommandValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<UserDto>.Failure(validationResult.Errors[0].ErrorMessage);
                }
                var user = await _unitOfWork.UserRepository.GetByUsernameAndPasswordAsync(request.Username, HashService.GenerateSha256Hash(request.Password));
                if (user == null)
                {
                    return Result<UserDto>.Failure("کاربری با این اطلاعات وجود ندارد.");
                }
                var userDto = _mapper.Map<UserDto>(user);
                return Result<UserDto>.Success(userDto);
            }
        }
    }
}

