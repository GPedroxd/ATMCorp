namespace ATMCorp.ATM.Back_System.Domain;

public abstract class ValueObject<T>
    where T : ValueObject<T>
{

    public override bool Equals(object obj)
    {
        var valObj = obj as T;
        
        if(ReferenceEquals(null, valObj))
            return false;

        return EqualsCore(valObj);
    }

    public static bool operator == (ValueObject<T> a, ValueObject<T> b)
    {
        if(ReferenceEquals(a, null) && ReferenceEquals(b, null)) 
            return true;
        
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        =>!(a == b);

    public override int GetHashCode()
        => GetHashCodeCore();

    public abstract bool EqualsCore(T other);
    public abstract int GetHashCodeCore();
}
