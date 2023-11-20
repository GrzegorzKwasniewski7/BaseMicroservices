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
    public class ReplenishBalanceHandler
    {
        private readonly IAccountRepository _accountRepository;

        public ReplenishBalanceHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Handle(ReplenishBalance request, CancellationToken cancellationToken)
        { 
            await _accountRepository.ReplenishBalance(request.Id, request.AddToBalance);
        }
    }
}
