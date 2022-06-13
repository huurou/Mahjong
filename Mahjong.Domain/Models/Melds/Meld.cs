using Mahjong.Domain.Models.Tiles;

namespace Mahjong.Domain.Models.Melds;

public class Meld
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
    /// 明槓か暗槓か区別する
    /// </summary>
    public bool Opened { get; }
    /// <summary>
    /// 鳴かれた牌
    /// </summary>
    public Tile? CalledTile { get; }
    /// <summary>
    /// 誰から鳴いたか
    /// </summary>
    public Player From { get; }

    public Meld(MeldType type, TileList tiles,
        bool opened = true, Tile? calledTile = null, Player from = Player.A)
    {
        Type = type;
        Tiles = tiles;
        Opened = opened;
        CalledTile = calledTile;
        From = from;
    }

    public override string ToString()
    {
        return $"{Type} {Tiles}";
    }
}