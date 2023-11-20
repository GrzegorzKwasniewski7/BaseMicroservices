using MediatR;
using MotleyApp.Application.Abstractions;
using MotleyApp.Application.Products.Commands;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Accounts.CommandHandlers
{    
    public class CreateAccountHandler : IRequestHandler<CreateAccount, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            var person = new Account
            {
                Nickname = request.NickName,
                Balance = request.Balance
            };

            return await _accountRepository.CreateNewAccount(person);
        }
    };
}
