using ATMCorp.ATM.Back_System.Domain.SnackMachine;
using FluentAssertions;

namespace ATMCorp.ATM.Back_System.Domain.Tests.SnackMachine;

public class ManeyTests
{
    
    [Fact]
    public void SumOfTwoMoneysProducesCurrectResult()
    {
        Money m1 = new(1,2,3,4,5,6,7);
        Money m2 = new(1, 2, 3, 4, 5, 6, 7);
    
        var sum = m1 + m2;

        sum.FiveCentCount.Should().Be(2);
        sum.TenCentCount.Should().Be(4);
        sum.QuarterCentCount.Should().Be(6);
        sum.OneDollarCount.Should().Be(8);
        sum.FiveDollarCount.Should().Be(10);
        sum.TenDollarCount.Should().Be(12);
        sum.TwentyDollarCount.Should().Be(14);
    }

    [Fact]
    public void MoneyIsEqualIfContainSameAmount()
    {
        Money m1 = new(1, 2, 3, 4, 5, 6, 7);
        Money m2 = new(1, 2, 3, 4, 5, 6, 7);

        m1.Should().Be(m2);
        m2.GetHashCode().Should().Be(m1.GetHashCode());
    }

    [Fact]
    public void MoneyIsNotEqualIfContaindifferentMoneyAmount()
    {
        Money dollar = new(0, 0, 0, 1, 0, 0, 0);
        Money fourQuarters = new(0, 0, 4, 0, 0, 0, 0);

        dollar.Should().NotBe(fourQuarters);
        dollar.GetHashCode().Should().NotBe(fourQuarters.GetHashCode());
    }

    [Theory]
    [InlineData(-1,0,0,0,0,0,0)]
    [InlineData(0, -2, 0, 0, 0, 0, 0)]
    [InlineData(0, 0, -3, 0, 0, 0, 0)]
    [InlineData(0, 0, 0, -4, 0, 0, 0)]
    [InlineData(0, 0, 0, 0, -5, 0, 0)]
    [InlineData(0, 0, 0, 0, 0, -6, 0)]
    [InlineData(0, 0, 0, 0, 0, 0, -7)]
    public void CannotCreateMoneyWithNegativeValue(
            int fivec,
            int tenc,
            int quarter,
            int dollar,
            int fiveD,
            int tenD,
            int twentyd
        )
    {
        var action = () => new Money(
                fivec,
                tenc,
                quarter,
                oneDollarCount: dollar,
                fiveD,
                tenD,
                twentyd
            );

        action.Should().Throw<InvalidOperationException>();
    }

    [Theory]
    [InlineData(0, 0, 0, 0, 0, 0, 0, 0)]
    [InlineData(1, 0, 0, 0, 0, 0, 0, 0.05)]
    [InlineData(1, 2, 0, 0, 0, 0, 0, 0.25)]
    [InlineData(1, 2, 3, 0, 0, 0, 0, 1.00)]
    [InlineData(1, 2, 3, 4, 0, 0, 0, 5.00)]
    [InlineData(1, 2, 3, 4, 5, 0, 0, 30.00)]
    [InlineData(1, 2, 3, 4, 5, 6, 0, 90.00)]
    [InlineData(1, 2, 3, 4, 5, 6, 7, 230.00)]
    [InlineData(3, 3, 0, 2, 3, 0, 0, 17.45)]
    public void AmoutIsCalculateCurrenctly(
            int fivec,
            int tenc,
            int quarter,
            int dollar,
            int fiveD,
            int tenD,
            int twentyd,
            decimal expcAmount)
    {
        var m = new Money(
                fivec,
                tenc,
                quarter,
                oneDollarCount: dollar,
                fiveD,
                tenD,
                twentyd
            );

        m.Amount.Should().Be(expcAmount);
    }


    [Fact]
    public void SubtractionOfMoneyProducesCorrentResult()
    {
        Money m1 = new(10, 10, 10, 10, 10, 10, 10);
        Money m2 = new(1, 2, 3, 5, 6, 7, 7);

        Money m3 = m1 - m2;

        m3.FiveCentCount.Should().Be(9);
        m3.TenCentCount.Should().Be(8);
        m3.QuarterCentCount.Should().Be(7);
        m3.OneDollarCount.Should().Be(5);
        m3.FiveDollarCount.Should().Be(4);
        m3.TenDollarCount.Should().Be(3);
        m3.TwentyDollarCount.Should().Be(3);
    }

    [Fact]
    public void CannotSubtractMoreMoneyThanExists()
    {
        Money m1 = new(0,0,1,1,0,0,0);
        Money m2 = new(1,3,1,0,0,0,0);

        var action = () => m1 - m2;
        
        action.Should().Throw<InvalidOperationException>();
    }
}
