using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 三槓子
/// </summary>
public record Sankantsu : Yaku
{
    public override string Name => "三槓子";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.ConcatFuuro(fuuroList).Count(x => x.IsKantsu) == 3;
    }
}
