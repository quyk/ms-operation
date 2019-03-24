using MS.Operation.Domain.Entities;
using MS.Operation.Domain.Enuns;

namespace MS.Operation.Infrastructure.Interfaces
{
    public interface ITransferRepository
    {
        OperationStatus Transfer(Transfer transfer);
    }
}
