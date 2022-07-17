namespace Mahjong.Domain;

public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
    where T : ValueObject<T>
{
    public abstract bool Equals(ValueObject<T>? other);

    public abstract int GetHashCodeCore();

    public override bool Equals(object? obj)
    {
        return Equals(obj as T);
    }

    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }

    public static bool operator ==(ValueObject<T>? vo1, ValueObject<T>? vo2)
    {
        return vo1?.Equals(vo2) ?? vo2 is null;
    }

    public static bool operator !=(ValueObject<T>? vo1, ValueObject<T>? vo2)
    {
        return !(vo1 == vo2);
    }
}