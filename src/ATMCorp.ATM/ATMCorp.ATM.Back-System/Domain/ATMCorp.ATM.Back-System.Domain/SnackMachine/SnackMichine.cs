namespace ATMCorp.ATM.Back_System.Domain.SnackMachine;

public sealed class SnackMichine : Entity
{
    public Money MoneyInside { get; private set; }
    public Money MoneyInTransaction { get; private set; }

    public void InsertMoney(Money money)
        => MoneyInTransaction += money;

    public void ReturnMoney() => throw new NotImplementedException();

    public void Buy()
    {
        MoneyInside += MoneyInTransaction;
    }
}
