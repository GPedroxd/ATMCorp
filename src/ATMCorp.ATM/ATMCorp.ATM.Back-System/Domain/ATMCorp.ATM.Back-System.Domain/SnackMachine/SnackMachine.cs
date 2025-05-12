using static ATMCorp.ATM.Back_System.Domain.SnackMachine.Money;

namespace ATMCorp.ATM.Back_System.Domain.SnackMachine;

public sealed class SnackMachine : Entity
{
    public static readonly Money[] AcceptedsCoinsAndNotes = [FiveCent, TenCent, Quarter, Dollar, Fivedollar, TenDollar, TwentyDollar];

    public Money MoneyInside { get; private set; } = None;
    public Money MoneyInTransaction { get; private set; } = None;

    public void InsertMoney(Money money)
    {
        if(!AcceptedsCoinsAndNotes.Contains(money))
            throw new InvalidOperationException();

        MoneyInTransaction += money;
    }
    public void ReturnMoney()
    {
        MoneyInTransaction = None;
    }
    public void Buy()
    {
        MoneyInside += MoneyInTransaction;
        MoneyInTransaction = None;
    }
}
