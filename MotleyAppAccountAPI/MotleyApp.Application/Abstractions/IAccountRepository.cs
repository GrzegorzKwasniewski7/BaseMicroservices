using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Application.Abstractions
{
    public interface IAccountRepository
    {  
        Task<Account> GetAccountById(int accountId);

        Task<Account> CreateNewAccount(Account toCreate);

        Task<Account?> UpdateAccount(int accountId, string nickName, decimal balance);

        Task DeleteAccount(int accountId);
        Task CompleteOrder();
        Task AddProductToCart();
        Task ReplenishBalance(int accountId, decimal addToBalance);
    }
}
