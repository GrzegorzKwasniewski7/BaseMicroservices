using AutoMapper;
using MotleyApp.Application.Accounts.Commands;
using MotleyApp.Application.Products.Commands;
using MotleyApp.Domain.Entities;
using MotleyAppAPI.DTOs;
using System.Runtime.InteropServices;

namespace MotleyAppAPI.Profiles
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDTO, CreateAccount>();
            CreateMap<CreateAccount, CreateAccountDTO>();
            CreateMap<UpdateAccountDTO, UpdateAccount>();
            CreateMap<UpdateAccount, UpdateAccountDTO>();
            CreateMap<ReplenishBalanceDTO, ReplenishBalance>();
            CreateMap<ReplenishBalance, ReplenishBalanceDTO>();
            CreateMap<AddProductToCartDTO, AddProductToCart>();
            CreateMap<AddProductToCart, AddProductToCartDTO>();
        }
    }
}
