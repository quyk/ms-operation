using MS.Operation.Domain.Entities;
using System.Collections.Generic;

namespace MS.Operation.Application.Interfaces
{
    public interface IAccountService
    {
        IList<Account> Get();
        Account GetByNumber(Account account);
    }
}
