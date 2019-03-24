using System.Collections.Generic;
using System.Linq;
using MS.Operation.Domain.Entities;
using MS.Operation.Infrastructure.Interfaces;

namespace MS.Operation.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IList<Account> _accounts;
        private readonly ISetupRepository _setupRepository;

        public AccountRepository(ISetupRepository setupRepository)
        {
            _setupRepository = setupRepository;
            _accounts = _setupRepository.Initialize();
        }

        public IList<Account> Get()
        {
            return _accounts;
        }

        public Account GetByNumber(Account account)
        {
            return _accounts.SingleOrDefault(x => x.Number == account.Number);
        }

        public bool Credit(Account account, double value)
        {
            var current = GetByNumber(account);
            if (current != null)
            {
                var balance = current.Balance + value;
                Update(current, balance);
                return true;
            }

            return false;
        }

        public bool Debit(Account account, double value)
        {
            var current = GetByNumber(account);

            if (current != null)
            {
                var balance = current.Balance - value;
                if (balance > 0 || current.Limit )
                {
                    Update(current, balance);
                    return true;
                }
            }

            return false;

        }

        public bool Exist(Account account)
        {
            return _accounts.FirstOrDefault(x => x.Number == account.Number) != null;
        }

        private void Update(Account account, double value)
        {
            _accounts.FirstOrDefault(x => x.Number == account.Number).Balance = value;
        }
    }
}
