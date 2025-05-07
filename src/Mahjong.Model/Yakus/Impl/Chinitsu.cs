using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 清一色
/// </summary>
public record Chinitsu : Yaku
{
    public override string Name => "清一色";
    public override int HanOpen => 5;
    public override int HanClosed => 6;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var combined = hand.CombineFuuro(fuuroList);
        return combined.All(x => x.IsAllMan) || combined.All(x => x.IsAllPin) || combined.All(x => x.IsAllSou);
    }
}
