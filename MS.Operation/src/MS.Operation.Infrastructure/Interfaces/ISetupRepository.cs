using System.Collections.Generic;
using MS.Operation.Domain.Entities;

namespace MS.Operation.Infrastructure.Interfaces
{
    public interface ISetupRepository
    {
        IList<Account> Initialize();
    }
}
