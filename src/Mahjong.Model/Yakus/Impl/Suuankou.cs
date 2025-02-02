using Mahjong.Model.Fuuro;
using Mahjong.Model.Games;
using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 四暗刻
/// </summary>
public record Suuankou : Yaku
{
    public override string Name => "四暗刻";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, TileList winGroup, FuuroList fuuroList, WinSituation situation)
    {
        var ankoTiles =
            situation.Tsumo ? hand.Where(x => x.IsKoutsu)
            : hand.Where(x => x.IsKoutsu && x != winGroup);
        var ankanTiles = fuuroList.Where(x => x.IsAnkan).Select(x => x.TileList);
        return ankoTiles.Count() + ankanTiles.Count() == 4;
    }
}
