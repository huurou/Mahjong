using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 小三元
/// </summary>
public record Shousangen : Yaku
{
    public override string Name => "小三元";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return (hand.FirstOrDefault(x => x.IsToitsu)?.FirstOrDefault()?.IsDragon ?? false) &&
            hand.Where(x => x.IsKoutsu && x[0].IsDragon)
                .Concat(fuuroList.Where(x => (x.IsPon || x.IsKan) && x.TileList[0].IsDragon).Select(x => x.TileList))
                .Count() == 2;
    }
}
