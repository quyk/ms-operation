using System.ComponentModel;

namespace MS.Operation.Domain.Enuns
{
    public enum OperationStatus
    {
        [Description("Saldo insuficiente")]
        NoBalance,
        [Description("Conta de origem inválida")]
        InvalidOriginAccount,
        [Description("Conta de destino inválida")]
        InvalidDestinationAccount,
        [Description("Dados inválido")]
        InvalidData,
        [Description("Sucesso")]
        Success,
        [Description("Tente novamente mais tarde")]
        TryAgainLater
    }
}
