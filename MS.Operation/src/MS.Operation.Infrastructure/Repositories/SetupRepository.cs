using MS.Operation.Domain.Entities;
using MS.Operation.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace MS.Operation.Infrastructure.Repositories
{
    public class SetupRepository : ISetupRepository
    {
        private static IList<Account> _accounts;

        public IList<Account> Initialize()
        {
            _accounts = _accounts ?? Setup();
            return _accounts;
        }

        private IList<Account> Setup()
        {
            return new List<Account>
            {
                new Account
                {
                    Number = 3064,
                    Balance = 100.00,
                    Limit = true
                },
                new Account()
                {
                    Number = 0810,
                    Balance = 50.00,
                    Limit = false
                },
                new Account
                {
                    Number = 3025,
                    Balance = 500.00,
                    Limit = false
                },
                new Account
                {
                    Number = 0553,
                    Balance = 0.00,
                    Limit = false
                },
                new Account
                {
                    Number = 3322,
                    Balance = -10.00,
                    Limit = true
                },
                new Account
                {
                    Number = 6828,
                    Balance = 125.00,
                    Limit = false
                }
            };
        }
    }
}
