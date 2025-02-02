using Mahjong.Model.Fuuro;
using Mahjong.Model.Games;
using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 自風牌
/// </summary>
public record PlayerWind : Yaku
{
    public override string Name => "自風牌";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList, WinSituation situation)
    {
        var windTile = situation.Player switch
        {
            Wind.East => Tile.Ton,
            Wind.South => Tile.Nan,
            Wind.West => Tile.Sha,
            Wind.North => Tile.Pei,
            _ => throw new NotSupportedException()
        };
        return hand.ConcatFuuro(fuuroList).IncludesKoutsu(windTile);
    }
}
