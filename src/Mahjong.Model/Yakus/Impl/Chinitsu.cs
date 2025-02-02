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
        var concated = hand.ConcatFuuro(fuuroList);
        return concated.All(x => x.IsAllMan) || concated.All(x => x.IsAllPin) || concated.All(x => x.IsAllSou);
    }
}
