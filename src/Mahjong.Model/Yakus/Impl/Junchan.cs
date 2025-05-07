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
        var combined = hand.CombineFuuro(fuuroList);
        var shuntsus = combined.Count(x => x.IsShuntsu);
        var routous = combined.Count(x => x.Any(x => x.IsRoutou));
        return shuntsus != 0 && routous == 5;
    }
}
