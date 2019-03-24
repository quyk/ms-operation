using System.Collections.Generic;
using MS.Operation.Domain.Entities;

namespace MS.Operation.Infrastructure.Interfaces
{
    public interface IAccountRepository
    {
        IList<Account> Get();
        Account GetByNumber(Account account);
        bool Credit(Account account, double value);
        bool Debit(Account account, double value);
        bool Exist(Account account);
    }
}
