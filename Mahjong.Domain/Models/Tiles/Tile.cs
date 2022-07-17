using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles;

/// <summary>
/// 牌 0~135のIdを持つ
/// </summary>
internal class Tile : ValueObject<Tile>
{
    public static Tile FIVE_RED_MAN => new(16);
    public static Tile FIVE_RED_PIN => new(52);
    public static Tile FIVE_RED_SOU => new(88);

    public int Id { get; }

    public TileKind Kind => Id is >= 0 and <= 135
        ? (TileKind)(Id / 4 + 1)
        : None;

    public Tile(int id)
    {
        if (id is < 0 or > 135) throw new ArgumentException($"タイルIDには0から135までを指定してください given:{id}", nameof(id));
        Id = id;
    }

    public static Tile Parse(string man = "", string pin = "", string sou = "", string honor = "")
    {
        return TileList.Parse(man, pin, sou, honor)[0];
    }

    public override bool Equals(ValueObject<Tile>? other)
    {
        return other is Tile tile && Id == tile.Id;
    }

    public override int GetHashCodeCore()
    {
        return new { Id }.GetHashCode();
    }

    public string ToString(bool printAkaDora)
    {
        return Kind.ToString(printAkaDora);
    }

    public override string ToString()
    {
        return Kind.ToString(false);
    }
}