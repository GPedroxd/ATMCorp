namespace ATMCorp.ATM.Back_System.Domain.SnackMachine;

public sealed class Money : ValueObject<Money>
{
    public int FiveCentCount { get; init; }
    public int TenCentCount { get; init; }
    public int QuarterCentCount { get; init; }
    public int OneDollarCount { get; init; }
    public int FiveDollarCount { get; init; }
    public int TenDollarCount { get; init; }
    public int TwentyDollarCount { get; init; }

    public decimal Amount
    {
        get => FiveCentCount * 0.05m +
            TenCentCount * 0.1m +
            QuarterCentCount * 0.25m +
            OneDollarCount +
            FiveDollarCount * 5 +
            TenDollarCount * 10 +
            TwentyDollarCount * 20;
    }

    public Money(
        int fiveCentCount, int tenCentCount, int quarterCentCount,
        int oneDollarCount, int fiveDollarCount, int tenDollarCount, int twentyDollarCount)
    {

        if (fiveCentCount < 0)
            throw new InvalidOperationException();

        if (tenCentCount < 0)
            throw new InvalidOperationException();
        
        if (quarterCentCount < 0)
            throw new InvalidOperationException();

        if (oneDollarCount < 0)
            throw new InvalidOperationException();

        if (fiveDollarCount < 0)
            throw new InvalidOperationException();
        
        if (tenDollarCount < 0)
            throw new InvalidOperationException();

        if (twentyDollarCount < 0)
            throw new InvalidOperationException();

        FiveCentCount = fiveCentCount;
        TenCentCount = tenCentCount;
        QuarterCentCount = quarterCentCount;
        OneDollarCount = oneDollarCount;
        FiveDollarCount = fiveDollarCount;
        TenDollarCount = tenDollarCount;
        TwentyDollarCount = twentyDollarCount;
    }

    public static Money operator + (Money m1, Money m2)
        => new Money(
                m1.FiveCentCount + m2.FiveCentCount,
                m1.TenCentCount + m2.TenCentCount,
                m1.QuarterCentCount + m2.QuarterCentCount,
                m1.OneDollarCount + m2.OneDollarCount,
                m1.FiveDollarCount + m2.FiveDollarCount,
                m1.TenDollarCount + m2.TenDollarCount,
                m1.TwentyDollarCount + m2.TwentyDollarCount
            );

    public static Money operator - (Money m1, Money m2)
    => new Money(
                m1.FiveCentCount - m2.FiveCentCount,
                m1.TenCentCount - m2.TenCentCount,
                m1.QuarterCentCount - m2.QuarterCentCount,
                m1.OneDollarCount - m2.OneDollarCount,
                m1.FiveDollarCount - m2.FiveDollarCount,
                m1.TenDollarCount - m2.TenDollarCount,
                m1.TwentyDollarCount - m2.TwentyDollarCount
            );

    public override bool EqualsCore(Money other)
        => FiveCentCount == other.FiveCentCount &&
        TenCentCount == other.TenCentCount &&
        QuarterCentCount == other.QuarterCentCount &&
        OneDollarCount == other.OneDollarCount &&
        FiveDollarCount == other.FiveDollarCount &&
        TenDollarCount == other.TenDollarCount &&
        TwentyDollarCount == other.TwentyDollarCount;

    public override int GetHashCodeCore()
        => HashCode.Combine(
           FiveCentCount,
           TenCentCount,
           QuarterCentCount,
           OneDollarCount,
           FiveDollarCount,
           TenDollarCount,
           TwentyDollarCount);

}
