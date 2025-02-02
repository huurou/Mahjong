using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 大三元
/// </summary>
public record Daisangen : Yaku
{
    public override string Name => "大三元";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var concated = hand.ConcatFuuro(fuuroList);
        return concated.Count(x => (x.IsKoutsu || x.IsKantsu) && x.All(x => x.IsDragon)) == 3;
    }
}
