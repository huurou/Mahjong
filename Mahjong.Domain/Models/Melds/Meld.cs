using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.Melds.MeldType;

namespace Mahjong.Domain.Models.Melds;

internal class Meld : ValueObject<Meld>
{
    /// <summary>
    /// 鳴きの種類
    /// </summary>
    public MeldType Type { get; }
    /// <summary>
    /// 副露牌
    /// </summary>
    public TileList Tiles { get; }
    /// <summary>
    /// 副露牌(牌種別)
    /// </summary>
    public TileKindList Kinds => Tiles.ToKindList();
    /// <summary>
    /// 鳴かれた牌
    /// </summary>
    public Tile? CalledTile { get; }
    /// <summary>
    /// 誰から鳴いたか
    /// </summary>
    public Player From { get; }

    public bool IsKan => Type is Ankan or Shouminkan or Daiminkan;

    public bool IsOpen => Type is Chi or Pon or Shouminkan or Daiminkan;

    public Meld(MeldType type, TileList tiles, Tile? calledTile = null, Player from = Player.A)
    {
        if (tiles.Count is not (3 or 4)) throw new ArgumentException("牌の数は3つか4つです。", nameof(tiles));
        if (tiles.Count == 3 && type is Ankan or Shouminkan or Daiminkan) throw new ArgumentException("鳴き種別がカンですが牌数のが3つです。", nameof(tiles));
        if (tiles.Count == 4 && type is not (Ankan or Shouminkan or Daiminkan)) throw new ArgumentException("鳴き種別がカン以外ですが牌の数が4つです。", nameof(tiles));
        Type = type;
        Tiles = tiles;
        CalledTile = calledTile;
        From = from;
    }

    public override string ToString()
    {
        return $"{Type} {Tiles}";
    }

    public override bool Equals(ValueObject<Meld>? other)
    {
        return other is Meld meld &&
            Type == meld.Type &&
            Tiles == meld.Tiles &&
            CalledTile == meld.CalledTile &&
            From == meld.From;
    }

    public override int GetHashCodeCore()
    {
        return new { Type, Tiles, CalledTile, From }.GetHashCode();
    }
}