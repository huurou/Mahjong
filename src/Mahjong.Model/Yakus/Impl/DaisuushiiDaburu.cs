using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 大四喜ダブル
/// </summary>
public record DaisuushiiDaburu : Yaku
{
    public override string Name => "大四喜";
    public override int HanOpen => 26;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return Daisuushii.Valid(hand, fuuroList);
    }
}
