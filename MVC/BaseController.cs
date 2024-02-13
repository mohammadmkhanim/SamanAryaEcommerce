using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MVC
{
    public abstract class BaseController<ControllerType> : Controller
    {
        protected readonly ILogger<ControllerType> _logger;
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;
        protected int _userId
        {
            get
            {
                return Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }

        protected BaseController(
            ILogger<ControllerType> logger = null,
            IMediator mediator = null,
            IMapper mapper = null)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }
    }

}