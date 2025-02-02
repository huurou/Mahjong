using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 混老頭
/// </summary>
public record Honroutou : Yaku
{
    public override string Name => "混老頭";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.ConcatFuuro(fuuroList).All(x => x.All(y => y.IsYaochuu));
    }
}
