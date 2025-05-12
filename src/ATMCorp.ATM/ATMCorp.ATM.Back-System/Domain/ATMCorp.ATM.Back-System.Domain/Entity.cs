namespace ATMCorp.ATM.Back_System.Domain;

public abstract class Entity
{
    public Guid Id { get; private set; }

    public override bool Equals(object obj)
    {
        var other = obj as Entity;

        if(ReferenceEquals(other, null))
            return false;

        if(ReferenceEquals(other, this))
            return true;

        if(GetType() != other.GetType())
            return false;
    
        if(Id == Guid.Empty || other.Id == Guid.Empty)
            return false;

        return Id == other.Id;
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return true;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
        => !(a.Id == b.Id);

    public override int GetHashCode()
        => (GetType().ToString() + Id).GetHashCode();
}
