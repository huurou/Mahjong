using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 純全帯么九
/// </summary>
public record Junchan : Yaku
{
    public override string Name => "純全帯么九";
    public override int HanOpen => 2;
    public override int HanClosed => 3;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var concated = hand.ConcatFuuro(fuuroList);
        var shuntsus = concated.Count(x => x.IsShuntsu);
        var routous = concated.Count(x => x.Any(x => x.IsRoutou));
        return shuntsus != 0 && routous == 5;
    }
}
