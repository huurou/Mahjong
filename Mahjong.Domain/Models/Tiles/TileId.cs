using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles;

/// <summary>
/// タイルID
/// 全ての牌を区別するID 0~135
/// </summary>
public class TileId : ValueObject<TileId>
{
    public int Value { get; }

    public TileId(int value)
    {
        if (value is < 0 or > 135) throw new ArgumentException($"タイルIDには0から135までを指定してください given:{value}", nameof(value));
        Value = value;
    }

    public override bool Equals(ValueObject<TileId>? other)
    {
        return other is TileId tileId && Value == tileId.Value;
    }

    public override int GetHashCodeCore()
    {
        return new { Value }.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}