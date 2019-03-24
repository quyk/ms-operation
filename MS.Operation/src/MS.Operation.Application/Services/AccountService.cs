using System.Collections.Generic;
using MS.Operation.Application.Interfaces;
using MS.Operation.Domain.Entities;
using MS.Operation.Infrastructure.Interfaces;

namespace MS.Operation.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IList<Account> Get()
        {
            return _accountRepository.Get();
        }

        public Account GetByNumber(Account account)
        {
            if (account != null)
            {
                return _accountRepository.GetByNumber(account);
            }

            return null;
        }
    }
}