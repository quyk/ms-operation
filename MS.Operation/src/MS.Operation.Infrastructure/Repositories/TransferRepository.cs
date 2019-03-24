using MS.Operation.Domain.Entities;
using MS.Operation.Domain.Enuns;
using MS.Operation.Infrastructure.Interfaces;

namespace MS.Operation.Infrastructure.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly IAccountRepository _accountRepository;

        public TransferRepository(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public OperationStatus Transfer(Transfer transfer)
        {
            if (_accountRepository.Debit(transfer.Origin, transfer.Value))
            {
                var result = _accountRepository.Credit(transfer.Destination, transfer.Value);

                if (result)
                {
                    return OperationStatus.Success;
                }
                else
                {
                    Roolback(transfer.Origin, transfer.Value);
                    return OperationStatus.NoBalance;
                }
            }

            return OperationStatus.NoBalance;
        }

        private void Roolback(Account account, double value)
        {
            _accountRepository.Credit(account, value);
        }
    }
}
