using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 純正九蓮宝燈
/// </summary>
public record JunseiChuurenpoutou : Yaku
{
    public override string Name => "純正九蓮宝燈";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand)
    {
        return Chuurenpoutou.Valid(hand) && hand.All(x => x.IsShuntsu);
    }
}
