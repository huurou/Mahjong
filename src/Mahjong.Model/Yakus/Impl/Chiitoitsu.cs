using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 七対子
/// </summary>
public record Chiitoitsu : Yaku
{
    public override string Name => "七対子";
    public override int HanOpen => 0;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;
    public static bool Valid(Hand hand)
    {
        return hand.Count() == 7 && hand.All(x => x.IsToitsu);
    }
}
