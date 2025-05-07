using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 小四喜
/// </summary>
public record Shousuushii : Yaku
{
    public override string Name => "小四喜";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var combined = hand.CombineFuuro(fuuroList);
        var koutsus = combined.Where(x => x.IsKoutsu || x.IsKantsu);
        var toitsus = combined.Where(x => x.IsToitsu);
        return combined.Where(x => x.IsKoutsu || x.IsKantsu).Count(x => x[0].IsWind) == 3 &&
            combined.Where(x => x.IsToitsu).Count(x => x[0].IsWind) == 1;
    }
}
