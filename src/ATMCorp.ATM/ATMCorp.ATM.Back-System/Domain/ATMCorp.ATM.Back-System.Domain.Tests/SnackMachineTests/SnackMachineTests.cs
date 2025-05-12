using ATMCorp.ATM.Back_System.Domain.SnackMachine;
using FluentAssertions;
using static ATMCorp.ATM.Back_System.Domain.SnackMachine.Money;

namespace ATMCorp.ATM.Back_System.Domain.Tests.SnackMachineTests;

public class SnackMachineTests
{
    [Fact]
    public void ReturnMoneyEmptiesMoneyInTransaction()
    {
        var snackMachine = new SnackMachine.SnackMachine();
        snackMachine.InsertMoney(Dollar);

        snackMachine.ReturnMoney();
        
        snackMachine.MoneyInTransaction.Amount.Should().Be(0m);  
    }

    [Fact]
    public void InsertedMoneyGoesToMoneyInTransaction()
    {
        var snackMachine = new SnackMachine.SnackMachine();

        snackMachine.InsertMoney(Dollar);
        snackMachine.InsertMoney(TwentyDollar);

        snackMachine.MoneyInTransaction.Amount.Should().Be(21m);
    }

    [Fact]
    public void CannotAcceptMoreThanOneCoinOrNoteAtATime()
    {
        var snackMachine = new SnackMachine.SnackMachine();
        var twoCent = FiveCent + FiveCent;

        var action = () => snackMachine.InsertMoney(twoCent);

       action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void MoneyInTransactionGoesToMoneyInsideAfterPurchase()
    {
        var snackMachine = new SnackMachine.SnackMachine();
        snackMachine.InsertMoney(Dollar);
        snackMachine.InsertMoney(Fivedollar);

        snackMachine.Buy();

        snackMachine.MoneyInTransaction.Should().Be(None);
        snackMachine.MoneyInside.Amount.Should().Be(6m);
    }
}
