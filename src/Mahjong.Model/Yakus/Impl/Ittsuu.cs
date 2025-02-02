using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 一発
/// </summary>
public record Ittsuu : Yaku
{
    public override string Name => "一気通貫";
    public override int HanOpen => 1;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var shuntsus = hand.ConcatFuuro(fuuroList).Where(x => x.IsShuntsu);
        if (shuntsus.Count() < 3) { return false; }
        var suits = new[]
        {
            shuntsus.Where(x=>x.IsAllMan),
            shuntsus.Where(x=>x.IsAllPin),
            shuntsus.Where(x=>x.IsAllSou),
        };
        foreach (var suit in suits)
        {
            if (suit.Count() < 3) { continue; }
            var nums = suit.Select(x => x.Select(y => y.Number));
            return nums.Any(x => x.SequenceEqual([1, 2, 3])) &&
                nums.Any(x => x.SequenceEqual([4, 5, 6])) &&
                nums.Any(x => x.SequenceEqual([7, 8, 9]));
        }
        return false;
    }
}
