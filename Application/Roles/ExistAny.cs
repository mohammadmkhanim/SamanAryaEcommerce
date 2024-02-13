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
    public class ExistAny
    {
        public class Query : IRequest<Result<bool>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<bool>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<bool>.Success(await _unitOfWork.RoleRepository.ExistAny());
            }
        }
    }
}

