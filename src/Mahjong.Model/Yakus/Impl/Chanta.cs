using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 混全帯么九
/// </summary>
public record Chanta : Yaku
{
    public override string Name => "混全帯么九";
    public override int HanOpen => 1;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var tileListList = hand.ConcatFuuro(fuuroList);
        var shuntsuCount = tileListList.Count(x => x.IsShuntsu);
        var routouCount = tileListList.Count(x => x.Any(y => y.IsRoutou));
        var honorCount = tileListList.Count(x => x.IsAllHonor);
        return shuntsuCount != 0 && routouCount + honorCount == 5 && routouCount != 0 && honorCount != 0;
    }
}
