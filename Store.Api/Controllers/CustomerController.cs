using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Shared.Commands;

namespace Store.Api.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerHandler _customerHandler;

        public CustomerController(ICustomerRepository customerRepository, CustomerHandler customerHandler)
        {
            _customerRepository = customerRepository;
            _customerHandler = customerHandler;
        }

        [HttpGet]
        [Route("{id}")]
        public GetByIdQueryResult Get([FromRoute]string id)
        {
            return _customerRepository.GetById(id);
        }

        [HttpPost]
        public ICommandResult Add([FromBody] CreateCustomerCommand command)
        {
            var result = _customerHandler.Handle(command);
            return result;
        }

        [HttpPost]
        [Route("{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            return null;
        }

        
    }
}