using MS.Operation.Domain.Entities;
using MS.Operation.Domain.Enuns;

namespace MS.Operation.Application.Interfaces
{
    public interface ITransferService
    {
        OperationStatus Transfer(Transfer transfer);
    }
}
