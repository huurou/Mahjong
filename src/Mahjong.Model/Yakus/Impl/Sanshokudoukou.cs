using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 三色同刻
/// </summary>
public record Sanshokudoukou : Yaku
{
    public override string Name => "三色同刻";
    public override int HanOpen => 2;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var koutsus = hand.ConcatFuuro(fuuroList).Where(x => x.IsKoutsu || x.IsKantsu).Select(x => x.Take(3).ToList());
        if (koutsus.Count() < 3) { return false; }
        var mans = koutsus.Where(x => x[0].IsMan);
        var pins = koutsus.Where(x => x[0].IsPin);
        var sous = koutsus.Where(x => x[0].IsSou);
        foreach (var man in mans)
        {
            foreach (var pin in pins)
            {
                foreach (var sou in sous)
                {
                    if (man[0].Number == pin[0].Number && pin[0].Number == sou[0].Number) { return true; }
                }
            }
        }
        return false;
    }
}
