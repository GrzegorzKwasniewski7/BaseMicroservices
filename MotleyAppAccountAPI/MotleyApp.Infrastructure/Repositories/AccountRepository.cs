using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MotleyApp.Application.Abstractions;
using MotleyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotleyApp.Infrastructure.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddProductToCart()
        {
            throw new NotImplementedException();
        }

        public Task CompleteOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<Account> CreateNewAccount(Account toCreate)
        {
            _context.Accounts.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteAccount(int accountId)
        {
            var account = _context.Accounts.Find(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            } 
        }

        public async Task<Account> GetAccountById(int accountId)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public async Task ReplenishBalance(int accountId, decimal addToBalance)
        {
            var accountToUpdate = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
            if (accountToUpdate == null) return;            
            accountToUpdate.Balance = addToBalance;

            await _context.SaveChangesAsync();
            
        }

        public async Task<Account?> UpdateAccount(int accountId, string nickName, decimal balance)
        {
            var accountToUpdate = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
            if (accountToUpdate == null) return null;
            accountToUpdate.Nickname = nickName;
            accountToUpdate.Balance = balance;

            await _context.SaveChangesAsync();
            return accountToUpdate;
        }
    }
}
