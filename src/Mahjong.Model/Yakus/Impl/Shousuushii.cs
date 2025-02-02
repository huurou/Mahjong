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
        var concated = hand.ConcatFuuro(fuuroList);
        var koutsus = concated.Where(x => x.IsKoutsu || x.IsKantsu);
        var toitsus = concated.Where(x => x.IsToitsu);
        return concated.Where(x => x.IsKoutsu || x.IsKantsu).Count(x => x[0].IsWind) == 3 &&
            concated.Where(x => x.IsToitsu).Count(x => x[0].IsWind) == 1;
    }
}
