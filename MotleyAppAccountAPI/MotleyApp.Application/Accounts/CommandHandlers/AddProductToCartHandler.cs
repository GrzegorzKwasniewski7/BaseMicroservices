using MotleyApp.Application.Abstractions;
using MotleyApp.Application.Accounts.Commands;
using MotleyApp.Application.Products.Commands;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Accounts.CommandHandlers
{
    public class AddProductToCartHandler
    {
        private readonly IAccountRepository _accountRepository;

        public AddProductToCartHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Handle(AddProductToCart request, CancellationToken cancellationToken)
        {
            // Should be implemented by Redis or other 
        }
    }
}
