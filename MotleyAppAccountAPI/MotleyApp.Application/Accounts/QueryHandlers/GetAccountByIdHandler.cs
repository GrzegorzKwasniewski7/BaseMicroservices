using MediatR;
using MotleyApp.Application.Abstractions;
using MotleyApp.Application.Products.Queries;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Products.QueryHandlers
{
    public class GetAccountByIdHandler: IRequestHandler<GetAccountById, Account>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> Handle(GetAccountById request, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAccountById(request.Id);
        }
    }
}
