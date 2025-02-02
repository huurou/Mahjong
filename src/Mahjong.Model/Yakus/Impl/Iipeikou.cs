using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 一盃口
/// </summary>
public record Iipeikou : Yaku
{
    public override string Name => "一盃口";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return !fuuroList.HasOpen && hand.Where(x => x.IsShuntsu).GroupBy(x => x).Any(x => x.Count() >= 2);
    }
}
