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
    public class UpdateAccountHandler
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task Handle(UpdateAccount request, CancellationToken cancellationToken)
        {
            await _accountRepository.UpdateAccount(request.Id, request.NickName, request.Balance);
        }
    }
}
