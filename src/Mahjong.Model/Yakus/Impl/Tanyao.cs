using Mahjong.Model.Fuuro;
using Mahjong.Model.Games;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 断么九
/// </summary>
public record Tanyao : Yaku
{
    public override string Name => "断么九";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList, GameRules rules)
    {
        return hand.ConcatFuuro(fuuroList).All(x => x.All(y => y.IsChuuchan)) &&
            (!fuuroList.HasOpen || rules.Kuitan);
    }
}
